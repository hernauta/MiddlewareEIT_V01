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
using MiddlewareEIT.API.Services;
using MiddlewareEIT.API.Authorization;
using RmiApiReversoEIT.Services;
using RmiLibServiciosEIT.Services;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    public class NroTicketController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        public NroTicketController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="nroTicket">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/ConfirmNroTicketExpEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string ConfirmNroTicketExpEIT([FromBodyAttribute] XElement nroTicketXml)
        {
            var audit = new AuditoriaDTO();
            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "ConfirmNroTicketExpEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = nroTicketXml.ToString(); //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            var nroTicketstr = nroTicketXml.ToString();
            var nroTicket = new NroTicketDTO();
            nroTicket = Serializar.DeserializarTo<NroTicketDTO>(nroTicketstr, false);
            var result = new NroTicketXML();

            using (var client = new HttpClient())
            {
                try
                {
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var request = NroTicketServiceEIT.GetRequestNroTicketExp(nroTicket);
                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    var soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "ConfirmNroTicketExpEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);
                    return (soapResponse1);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    var resultf = ex.Data;
                    return (ex.StackTrace);
                }
            }
        }


        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="nroTicket">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        [Route("api/ConfirmNroTicketImpEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string ConfirmNroTicketImpEIT([FromBodyAttribute] XElement nroTicketXml)
        {
            var audit = new AuditoriaDTO();
            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "ConfirmNroTicketImpEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = nroTicketXml.ToString(); //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            var nroTicketstr = nroTicketXml.ToString();
            var nroTicket = new NroTicketDTO();
            nroTicket = Serializar.DeserializarTo<NroTicketDTO>(nroTicketstr, false);
            var result = new NroTicketXML();

            using (var client = new HttpClient())
            {
                try
                {
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var request = NroTicketServiceEIT.GetRequestNroTicketImp(nroTicket);
                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    var soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "ConfirmNroTicketImpEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = nroTicketstr.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    var auditoria2 = new AuditoriasController(_logger, _context).CreateAuditoria(audit2);
                    return (soapResponse1);
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
