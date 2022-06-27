using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.API.Services;
using MiddlewareEIT.BL.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiddlewareEIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesaArchivoController : ControllerBase
    {
        /// <summary>
        /// Instancia servicios
        /// </summary>
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly BdMiddlewareEITContext _context2;
        private readonly IMapper _mapper;

        // GET: api/<ProcesaArchivoController>
        [HttpGet("{nombre}")]
        //public IEnumerable<string> Get(string nombre)
        public string GetArchivo(string nombre)
        {
            var audit = new AuditoriaDTO();
            var servidor = "ftp://192.168.100.13/";
            var usuario = "hernandurang@gmail.com";
            var password = "Lhasa654321";
            var archivoOrigen = nombre;
            var directorios2 = "";

            var Resumen = "";
            directorios2 = ProcesaArchivo.descargarftp(servidor, usuario, password, nombre);
            Resumen = Resumen + nombre + ": " + "\n" + directorios2 + "\n";

            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "GetArchivo-Process";
            audit.TipoEvento = "I";
            audit.Dato = Resumen; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = "Siemens";
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            return Resumen;
        }

        // GET: api/<ProcesaArchivoController>
        [HttpGet]
        //public IEnumerable<string> Get(string nombre)
        public string GetArchivos()
        {
            var audit = new AuditoriaDTO();
            var servidor = "ftp://192.168.100.13/";
            var usuario = "hernandurang@gmail.com";
            var password = "Lhasa654321";
            var directorios2 = "";

            var archivo2 = ProcesaArchivo.listarContenidoFTP(servidor, usuario, password);
            var Resumen = "";
            for (int i = 0; i < archivo2.Count; i++)
            {
                var nombrearch = archivo2[i].ToLower();
                directorios2 = ProcesaArchivo.descargarftp(servidor, usuario, password, nombrearch);
                Resumen = Resumen + nombrearch + ": " + "\n" + directorios2 + "\n";

            }
            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "GetArchivos-Process";
            audit.TipoEvento = "I";
            audit.Dato = Resumen; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = "Siemens";
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            return Resumen;
        }

        [HttpPost]
        //public IEnumerable<string> Get(string nombre)
        public string PostArchivos( string TipoArchivo )
        {
            var audit = new AuditoriaDTO();
            var servidor = "ftp://192.168.100.13/";
            var usuario = "hernandurang@gmail.com";
            var password = "Lhasa654321";
            var directorios2 = "";

            var archivo2 = ProcesaArchivo.CrearTxt(servidor, usuario, password, "contenido", TipoArchivo );
            var Resumen = "";
            //for (int i = 0; i < archivo2; i++)
            //{
            //    var nombrearch = archivo2[i].ToLower();
            //    directorios2 = ProcesaArchivo.descargarftp(servidor, usuario, password, nombrearch);
            //    Resumen = Resumen + nombrearch + ": " + "\n" + directorios2 + "\n";

            //}
            audit.Id = 0;
            audit.IdCliente = 0;
            audit.Metodo = "GetArchivos-Process";
            audit.TipoEvento = "I";
            audit.Dato = Resumen; //XmlCargaAudit
            audit.Fecha = (DateTime.Now);
            audit.Owner = "Siemens";
            var auditoria = new AuditoriasController(_logger, _context).CreateAuditoria(audit);

            return Resumen;
        }

    }
}
