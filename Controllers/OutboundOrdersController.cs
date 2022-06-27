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
using MiddlewareEIT.BL.Models;
using System.Collections.Generic;
using RmiLibReversoEIT.Services;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class OutboundOrdersController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public OutboundOrdersController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
            _context2 = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="outboundOrderXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/OutboundOrderEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string OutboundOrderEIT([FromBodyAttribute] XElement outboundOrderXml)
        {
            var audit = new AuditoriaDTO();
            var outboundOrderstr = outboundOrderXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var outboundOrder = new OutboundOrderDTO();
            outboundOrder = Serializar.DeserializarTo<OutboundOrderDTO>(outboundOrderstr, false);
            var Owner = outboundOrder.OwnCode;

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "OutboundOrderEIT-Request";
            audit.TipoEvento = "O";
            audit.Dato = outboundOrderstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            _context.SaveChanges();

            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);
                    var OutboundOrderValid = ValidaMetodosOwner.validarOutboundOrder(outboundOrder, "OutboundOrderEIT", Owner);

                    if (OutboundOrderValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (OutboundOrderValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (OutboundOrderValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (OutboundOrderValid.ToString()));
                    }

                    outboundOrder = Serializar.DeserializarTo<OutboundOrderDTO>(OutboundOrderValid, false);

                    var request = ConstructorXML.crearXMLOutbound(outboundOrder, userName, password);
                    //var request = VendorServiceEIT.GetRequestVendor(outboundOrder);
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

 
                    soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "OutboundOrderEIT-Response";
                    audit2.TipoEvento = "O";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    audit2.Owner = Owner;
                    var auditoria2 = new AuditoriasController(_logger, _context2).CreateAuditoria(audit2);
                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    var Relaciones = new AsignaRelacion().MetodoWms("OutboundOrderEIT", Owner);
                    if (Relaciones != 0)
                    {
                        camposWms = new AsignaRelacion().CamposWms(Relaciones);
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
