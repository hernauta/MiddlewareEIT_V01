using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.Models;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.API.Authorization;

namespace MiddlewareEIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        /// <summary>
        /// Instancia servicios
        /// </summary>
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;

        //BdMiddlewareEITContext bm = new BdMiddlewareEITContext();
        public AuditoriasController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context)
        {
            _logger = logger;
            _context = context;
        }

        private static AuditoriaDTO ItemToDTO(Auditoria auditoria) =>
            new AuditoriaDTO
            {

                Id = auditoria.Id,
                IdCliente = auditoria.IdCliente,
                Metodo = auditoria.Metodo,
                TipoEvento = auditoria.TipoEvento,
                Dato = auditoria.Dato,
                Fecha = auditoria.Fecha

            };

        // GET: api/Auditorias
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditoriaDTO>>> GetAuditoria()
        {
            
            _logger.LogInformation("Ejecuta proceso " + "GetAuditoria");
            List<AuditoriaDTO> auditoria = new List<AuditoriaDTO>();
            try
            {
                auditoria = await _context.Auditoria
                    .Select(x => ItemToDTO(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }
            return auditoria.ToList();
        }

        // GET: api/Auditorias/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditoriaDTO>> GetAuditoria(int id)
        {
            _logger.LogInformation("Ejecuta proceso " + "GetAuditoria");
            Auditoria auditoria = new Auditoria();
            try
            {
                auditoria = await _context.Auditoria.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }

            if (auditoria == null)
            {
                return NotFound();
            }

            return ItemToDTO(auditoria);
        }


        // POST: api/Auditorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AuditoriaDTO>> CreateAuditoria(AuditoriaDTO auditoriaDTO)
        {
            _logger.LogInformation("Ejecuta proceso " + "CreateAuditoria");

            if (auditoriaDTO.IdCliente == 0)
            {
                auditoriaDTO.IdCliente = 1;
            }
            else
            {
                auditoriaDTO.IdCliente = auditoriaDTO.IdCliente;
            }
            var auditoria = new Auditoria
            {

                IdCliente = auditoriaDTO.IdCliente,
                Metodo = auditoriaDTO.Metodo,
                TipoEvento = auditoriaDTO.TipoEvento,
                Dato = auditoriaDTO.Dato,
                Fecha = auditoriaDTO.Fecha
            };
            try
            {
                _context.Auditoria.Add(auditoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction(
                   nameof(GetAuditoria),
                   new { id = auditoria.Id },
                   ItemToDTO(auditoria));
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return NoContent();
            }                           
        }

        private bool AuditoriaExists(int id)
        {
            return _context.Auditoria.Any(e => e.Id == id);
        }
    }
}
