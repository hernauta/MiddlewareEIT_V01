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
using MiddlewareEIT.BL.DTOs.DTOs_Falabella;

namespace MiddlewareEIT.API.Controllers
{
    //[AllowAnonymous]
    [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    public class AsnFBController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public AsnFBController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
            _context2 = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="itemXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        [HttpPost]
        //[AllowAnonymous]
        [Route("api/AsnFBEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string AsnFBEIT([FromBodyAttribute] XElement asnXml)
        {
            var audit = new AuditoriaDTO();
            var asnstr = asnXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var asn = new  tXML();
            asn = Serializar.DeserializarTo<tXML>(asnstr, false);
            var Owner = "FRS";

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "AsnFBEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = asnstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);
            //dl.registraAuditoria(audit);

            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);
                    //Valida correcta asignación de valor a campos obligatorios
                    var asnValid = ValidaMetodosOwner.validarAsnFB(asn, "AsnFBEIT", Owner);
                    //Responde segun resultado de validación
                    if (asnValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (asnValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (asnValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (asnValid.ToString()));
                    }

                    //Trae metodoWMS relacionado al Metodo FRS
                    var Relaciones = new AsignaRelacion().MetodoWms("AsnFBEIT", Owner);
                    if (Relaciones != 0)
                    {
                        InboundOrderDTOFRS inboundOrderdto = new InboundOrderDTOFRS();
                        //Trae los campos relacionados al metodo
                        camposWms = new AsignaRelacion().CamposWms(Relaciones);

                        //Función de asignación de valores segun relaciónes
                        var relacionados = new AsignaRelacion().RelacionacamposASN(camposWms, asn);
                        var inboundOrderValidDTO = ValidaMetodosOwner.validarInboundOrderFRS(relacionados, "inboundOrderEIT", Owner);
                        inboundOrderdto = Serializar.DeserializarTo<InboundOrderDTOFRS>(inboundOrderValidDTO, false);


                        var request = ConstructorXML.crearXMLInboundFRS(relacionados, userName, password);
                        var XmlCargaAudit = new XmlCargaAudit();
                        var audit2 = new AuditoriaDTO();
                        soapResponse1 = Transform.Exec(request);

                        audit2.Id = 0;
                        audit2.IdCliente = 0;
                        audit2.Metodo = "AsnFBEIT-Response";
                        audit2.TipoEvento = "I";
                        audit2.Dato = request; //XmlCargaAudit
                        audit2.Fecha = (DateTime.Now);
                        audit2.Owner = Owner;
                        var auditoria2 = new AuditoriasController(_logger, _context2).CreateAuditoria(audit2);
                        //dl.registraAuditoria(audit2);

                        var content = new StringContent(request, Encoding.UTF8, "text/xml");

                        return (request);
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
