using System;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models.XMLs;
using RmiApiReversoEIT.Services;
using RmiLibReversoEIT.Services;
using RmiLibServiciosEIT.Services;
using MiddlewareEIT.API.Authorization;
using RmiLibFalabellaEIT.Services;
using MiddlewareEIT.BL.Models;
using System.Collections.Generic;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class InboundOrderController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public InboundOrderController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
            _context2 = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="inboundOrderXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/InboundOrderEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string InboundOrderEIT([FromBodyAttribute] XElement inboundOrderXml)
        {
            var audit = new AuditoriaDTO();
            var inboundOrderstr = inboundOrderXml.ToString();
            
            string userName = "";
            string password = "";            
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "InboundOrderEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = inboundOrderstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            var inboundOrder = new InboundOrderDTO();
            inboundOrder = Serializar.DeserializarTo<InboundOrderDTO>(inboundOrderstr, false);
            var Owner = inboundOrder.OwnCode;

            var result = new InboundOrderXML();
            using (var client = new HttpClient())
            {
                try
                    {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);

                    //if (inboundOrder.OwnCode == "FRS")
                    //{
                    //    var inboundOrdervalid = ValidaFalabella.validarInboundOrder(inboundOrder, "InboundOrderEIT", Owner);
                    //    if (inboundOrdervalid.ToString() == "No existen coincidencias con valor ingresado")
                    //    {
                    //        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT");
                    //        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT"));
                    //    }
                    //    if (inboundOrdervalid.ToString().Contains("El campo") == true)
                    //    {
                    //        return "StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString());
                    //        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString()));
                    //    }
                    //    inboundOrder = Serializar.DeserializarTo<InboundOrderDTO>(inboundOrdervalid, false);

                    //    var request = ConstructorXML.crearXMLInbound(inboundOrder, userName, password);
                    //    var XmlCargaAudit = new XmlCargaAudit();
                    //    var audit2 = new AuditoriaDTO();

                    //    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    //    soapResponse1 = Transform.Exec(request);

                    //    audit2.Id = 0;
                    //    audit2.IdCliente = 0;
                    //    audit2.Metodo = "InboundOrderEIT-Response";
                    //    audit2.TipoEvento = "I";
                    //    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    //    audit2.Fecha = (DateTime.Now);
                    //    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);
                    //}
                    
                    //if (inboundOrder.OwnCode == "PAT")
                    //{
                    //    var inboundOrdervalid = ValidaReverso.validarInboundOrder(inboundOrder);
                    //    if (inboundOrdervalid.ToString() == "No existen coincidencias con valor ingresado")
                    //    {
                    //        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT");
                    //        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT"));
                    //    }
                    //    if (inboundOrdervalid.ToString().Contains("El campo") == true)
                    //    {
                    //        return "StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString());
                    //        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString()));
                    //    }
                    //    inboundOrder = Serializar.DeserializarTo<InboundOrderDTO>(inboundOrdervalid, false);

                    //    var request = ConstructorXML.crearXMLInbound(inboundOrder, userName, password);
                    //    var XmlCargaAudit = new XmlCargaAudit();
                    //    var audit2 = new AuditoriaDTO();
                    //    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    //    soapResponse1 = Transform.Exec(request);
                    //    audit2.Id = 0;
                    //    audit2.IdCliente = 0;
                    //    audit2.Metodo = "InboundOrderEIT-Response";
                    //    audit2.TipoEvento = "I";
                    //    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    //    audit2.Fecha = (DateTime.Now);
                    //    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);                       
                    //}

                    //if (inboundOrder.OwnCode != "FRS" && inboundOrder.OwnCode != "PAT")
                    //{
                    var inboundOrdervalid = ValidaMetodosOwner.validarInboundOrder(inboundOrder, "InboundOrderEIT", Owner);
                    if (inboundOrdervalid.ToString() == "No existen coincidencias con valor ingresado")
                        {
                            return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT");
                            _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner, informar a EIT"));
                        }
                    if (inboundOrdervalid.ToString().Contains("El campo") == true)
                        {
                            return "StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString());
                            _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (inboundOrdervalid.ToString()));
                        }
                    inboundOrder = Serializar.DeserializarTo<InboundOrderDTO>(inboundOrdervalid, false);

                    var request = ConstructorXML.crearXMLInbound(inboundOrder, userName, password);
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();
                    
                    soapResponse1 = Transform.Exec(request);
                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "InboundOrderEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    var auditoria2 = new AuditoriasController(_logger, _context2).CreateAuditoria(audit2);
                    //}

                    var content = new StringContent(request, Encoding.UTF8, "text/xml");

                    var Relaciones = new AsignaRelacion().MetodoWms("InboundOrderEIT", Owner);
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
