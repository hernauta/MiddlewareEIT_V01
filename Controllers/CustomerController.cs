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
using RmiLibServiciosEIT.Services;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;

        BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        DAL dl = new DAL();
        public CustomerController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
            _context2 = context;
        }
        /// <summary>
        /// Inserta un objeto Course por su Id.
        /// </summary>
        /// <param name="customerXml">Objeto DTO</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve la correcta inserción del objeto.</response>
        /// <response code="400">BadRequest. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">ServerError. Error de acceso al servidor.</response>
        // POST: Transformador/Create
        //[AllowAnonymous]
        [HttpPost]
        [Route("api/CustomerEIT")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string CustomerEIT([FromBodyAttribute] XElement customerXml)
        {
            var audit = new AuditoriaDTO();
            var customerstr = customerXml.ToString();

            string userName = "";
            string password = "";
            var soapResponse1 = "";
            List<Campos> camposWms = new List<Campos>();

            var customer = new CustomerDTO();
            customer = Serializar.DeserializarTo<CustomerDTO>(customerstr, false);
            var Owner = customer.OwnCode;

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "CustomerEIT-Request";
            audit.TipoEvento = "I";
            audit.Dato = customerstr; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = Owner;
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            using (var client = new HttpClient())
            {
                try
                {
                    userName = dl.GetParametrosByName("userName" + Owner);
                    password = dl.GetParametrosByName("password" + Owner);
                    var customerValid = ValidaMetodosOwner.validarCustomer(customer, "BranchEIT", Owner);


                    if (customerValid.ToString() == "No existen coincidencias con valor ingresado")
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT");
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + ("No existen Metodos y/o campos asociados al Owner " + Owner + ", informar a EIT"));
                    }
                    if (customerValid.ToString().Contains("El campo") == true)
                    {
                        return "StatusCode " + BadRequest().StatusCode + "-" + (customerValid.ToString());
                        _logger.LogError("StatusCode " + BadRequest().StatusCode + "-" + (customerValid.ToString()));
                    }

                    customer = Serializar.DeserializarTo<CustomerDTO>(customerValid, false);

                    var request = CustomerServiceEIT.GetRequestCustomer2(customer);
                    var XmlCargaAudit = new XmlCargaAudit();
                    var audit2 = new AuditoriaDTO();

                    var content = new StringContent(request, Encoding.UTF8, "text/xml");
                    soapResponse1 = Transform.Exec(request);

                    audit2.Id = 0;
                    audit2.IdCliente = 0;
                    audit2.Metodo = "CustomerEIT-Response";
                    audit2.TipoEvento = "I";
                    audit2.Dato = soapResponse1.ToString(); //XmlCargaAudit
                    audit2.Fecha = (DateTime.Now);
                    var auditoria2 = new AuditoriasController(_logger, _context2).CreateAuditoria(audit2);

                    var Relaciones = new AsignaRelacion().MetodoWms("CustomerEIT", Owner);
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
