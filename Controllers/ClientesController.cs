using Microsoft.AspNetCore.Mvc;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiddlewareEIT.API.Authorization;
using Microsoft.Extensions.Logging;
using System;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly BdMiddlewareEITContext _context;

        public ClientesController(ILogger<ClientesController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
        }

        private static ClienteDTO ItemToDTO(Cliente cliente) => 
            new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                RutCliente = cliente.RutCliente,
                DvCliente = cliente.DvCliente,
                Libreria = cliente.Libreria,
                UsuarioWms = cliente.UsuarioWms,
                PasswordWms = cliente.PasswordWms
            };

        // GET: api/Clientes/5
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> GetAllCliente()
        {

            _logger.LogInformation("Ejecuta proceso " + "GetAllCliente");
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            try
            {
               clientes =  await _context.Clientes
                        .Select(x => ItemToDTO(x))
                        .ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex + ex.Message);
            }

            return clientes.ToList();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetClienteID(int id)
        {
            _logger.LogInformation("Ejecuta proceso " + "GetClienteID");
            Cliente cliente = new Cliente();
            try
            {
                cliente = await _context.Clientes.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }

            if (cliente == null)
            {
                return NotFound();
            }
            return ItemToDTO(cliente);
        }

        // GET: api/Clientes/5
        [HttpGet("{usuario}")]
        public async Task<ActionResult<ClienteDTO>> GetClienteUsu(string usuario)
        {
            _logger.LogInformation("Ejecuta proceso " + "GetClienteUsu");
            Cliente cliente = new Cliente();
            try
            {
                 cliente = _context.Clientes.Where(e => e.UsuarioWms == usuario).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }

            if (cliente == null)
            {
                return NotFound();
            }

            var User = cliente ;

            return ItemToDTO(User);
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
