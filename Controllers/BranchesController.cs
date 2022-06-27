using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.API.Authorization;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models;
using MiddlewareEIT.BL.Models.XMLs;
using RmiApiReversoEIT.Services;
using RmiLibReversoEIT.Services;
using RmiLibServiciosEIT.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public BranchesController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
            _context2 = context;
        }

        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="branchXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        //[AllowAnonymous]
        [HttpPost]
        [Route("api/BranchEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string BranchEIT([FromBodyAttribute] XElement branchXml)
        {
            var audit = new AuditoriaDTO();
            var branchstr = branchXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var branch = new BranchDTO();
            branch = Serializar.DeserializarTo<BranchDTO>(branchstr, false);
            var Owner = branch.OwnCode;

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "BranchEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = branchstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger , _context ).CreateAuditoria(audit);
                     
            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName"+Owner);
                    password = dl.GetParametrosByName("password"+Owner);
                    var branchValid = ValidaMetodosOwner.validarBranch(branch, "BranchEIT", Owner);
                    if (branchValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner "+ Owner +", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (branchValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (branchValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (branchValid.ToString()));
                    }

                    branch = Serializar.DeserializarTo<BranchDTO>(branchValid, false);

                    var request = ConstructorXML.crearXMLBranch(branch, userName, password);
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "BranchEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    audit2.Owner = Owner;
                    var auditoria2 = new AuditoriasController(_logger, _context2).CreateAuditoria(audit2);

                    var Relaciones = new AsignaRelacion().MetodoWms("BranchEIT", Owner);
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
