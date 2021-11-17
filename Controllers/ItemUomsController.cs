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
using RmiLibReversoEIT.Services;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class ItemUomsController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public ItemUomsController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="itemUomXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/ItemUomEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string ItemUomEIT([FromBodyAttribute] XElement itemUomXml)
        {
            var audit = new AuditoriaDTO();
            var itemUomstr = itemUomXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var itemUom = new ItemUomDTO();
            itemUom = Serializar.DeserializarTo<ItemUomDTO>(itemUomstr, false);
            var Owner = itemUom.OwnCode;

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "ItemUomEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = itemUomstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);
                    var itemUomValid = ValidaMetodosOwner.validarItemUom(itemUom, "ItemUomEIT", Owner);

                    if (itemUomValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (itemUomValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (itemUomValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (itemUomValid.ToString()));
                    }

                    itemUom = Serializar.DeserializarTo<ItemUomDTO>(itemUomValid, false);

                    var request = ConstructorXML.crearXMLItemUom(itemUom, userName, password);
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "ItemUomEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    audit2.Owner = Owner;
                    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);

                    var Relaciones = new AsignaRelacion().relacionService("ItemUomEIT", Owner);
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
