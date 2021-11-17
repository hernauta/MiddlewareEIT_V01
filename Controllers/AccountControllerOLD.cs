using MiddlewareEIT.API.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.API.Services;
using RmiLibServiciosEIT.Services;
using System.Xml.Linq;
using MiddlewareEIT.API.Models.Users;

namespace MiddlewareEIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountControllerOLD : ControllerBase
    {

        /// <summary>
        /// Instancia servicios Loggin
        /// </summary>
        private readonly ILogger<AccountControllerOLD> _logger;
        private IUserService _userService;
        public AccountControllerOLD(ILogger<AccountControllerOLD> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Metodo encargado de hacer autenticación
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        [Microsoft.AspNetCore.Mvc.Consumes("application/xml")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status201Created)]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBodyAttribute] XElement modelXml)
        {
            AuthenticateRequest authenticate = new AuthenticateRequest();
            var modelStr = modelXml.ToString();
            authenticate = Serializar.DeserializarTo<AuthenticateRequest>(modelStr, false);

            _logger.LogInformation("Ejecuta proceso " + "GetToken");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = _userService.Authenticate(authenticate);

            if (response == null)
            {
                return Unauthorized();
                //return BadRequest(new { message = "Username or password is incorrect" });
            }
            else
            {
                return Ok(response);
            }
        }

        /////// <summary>
        /////// Metodo encargado de hacer autenticación
        /////// </summary>
        /////// <param name="loginDTO"></param>
        /////// <returns></returns>
        ////[HttpPost("authenticateJson")]
        ////public IActionResult AuthenticateJson(AuthenticateRequest model)
        ////{
        ////    _logger.LogInformation("Ejecuta proceso " + "GetToken");


        ////    if (!ModelState.IsValid)
        ////        return BadRequest(ModelState);
        ////    var response = _userService.Authenticate(model);

        ////    if (response == null)
        ////    {
        ////        return Unauthorized();
        ////        //return BadRequest(new { message = "Username or password is incorrect" });
        ////    }
        ////    else
        ////    {
        ////        return Ok(response);
        ////    }
        ////}
    }
}
