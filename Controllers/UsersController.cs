using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MiddlewareEIT.API.Authorization;
using MiddlewareEIT.API.Helpers;
using MiddlewareEIT.API.Models.Users;
using MiddlewareEIT.API.Services;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        private static UserDTO ItemToDTO(User user) =>
        new UserDTO
        {
            IdCliente = user.IdCliente,
            RutCliente = user.RutCliente,
            DvCliente = user.DvCliente,
            Libreria = user.Libreria,
            UsuarioWms = user.UsuarioWms,
            PasswordWms = user.PasswordWms
        };

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _userService.Register(model);
            return Ok(new { message = "Registro correctro" });

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "Usuario actualizado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "Usuario eliminado" });
        }
    }
}
