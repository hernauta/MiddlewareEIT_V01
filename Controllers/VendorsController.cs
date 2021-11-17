using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models.XMLs;
using MiddlewareEIT.API.Services;
using RmiApiReversoEIT.Services;
using RmiLibServiciosEIT.Services;
using System;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using MiddlewareEIT.API.Authorization;
using System.Collections.Generic;
using MiddlewareEIT.BL.Models;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public VendorsController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="vendor">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/VendorEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string VendorEIT([FromBodyAttribute] XElement vendorXml)
        {
            var audit = new AuditoriaDTO();
            var vendorstr = vendorXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var vendor = new VendorDTO();
            vendor = Serializar.DeserializarTo<VendorDTO>(vendorstr, false);
            var Owner = vendor.OwnCode;

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "VendorEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = vendorXml.ToString(); //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);
                    var vendorValid = ValidaMetodosOwner.validarVendor(vendor, "VendorEIT", Owner);

                    if (vendorValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (vendorValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (vendorValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (vendorValid.ToString()));
                    }

                    vendor = Serializar.DeserializarTo<VendorDTO>(vendorValid, false);

                   // var request = ConstructorXML.crearXMLBranch(vendor, userName, password);
                    var request = VendorServiceEIT.GetRequestVendor(vendor);

                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "VendorEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    audit2.Owner = Owner;
                    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);

                    var Relaciones = new AsignaRelacion().relacionService("VendorEIT", Owner);
                    if (Relaciones != 0)
                    {
                        camposWms = new AsignaRelacion().relacionarCampos(Relaciones);
                        return (soapResponse1);
                    }
                    else
                    {
                        return (soapResponse1);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    var resultf = ex.Data;
                    return (ex.StackTrace);
                }
            }
        }
    }
}
