using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareEIT.API.Authorization;
using MiddlewareEIT.BL.Data;
using MiddlewareEIT.BL.DTOs;
using MiddlewareEIT.BL.Models;
using RmiLibServiciosEIT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareEIT.API.Controllers
{
    [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        /// <summary>
        /// Instancia servicios
        /// </summary>
        private readonly ILogger<AuditoriasController> _logger;
        private readonly BdMiddlewareEITContext _context;
        private readonly IMapper _mapper;


        public StocksController(ILogger<AuditoriasController> logger, BdMiddlewareEITContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        private static StockDTO ItemToDTO(Stock stock)
        {
            var fechaActual = (DateTime.Now);
            return new StockDTO
            {

                IdWhs = stock.IdWhs,
                WhsCode = stock.WhsCode,
                ShortWhsName = stock.ShortWhsName,
                OwnCode = stock.OwnCode,
                OwnName = stock.OwnName,
                IdItem = stock.IdItem,
                ItemCode = stock.ItemCode,
                ShortItemName = stock.ShortItemName,
                ItemDescription = stock.ItemDescription,
                QtyStock = stock.QtyStock,
                QtyCicleCount = stock.QtyCicleCount,
                QtyReserved = stock.QtyReserved,
                QtyReceived = stock.QtyReceived,
                QtyStg = stock.QtyStg,
                QtyStgd = stock.QtyStgd,
                QtyStgr = stock.QtyStgr,
                QtyPendingPicking = stock.QtyPendingPicking,
                QtyTaskPicking = stock.QtyTaskPicking,
                QtyTaskSimulation = stock.QtyTaskSimulation,
                QtyHolded = stock.QtyHolded,
                QtyDock = stock.QtyDock,
                QtyTruck = stock.QtyTruck,
                QtyTotal = stock.QtyTotal,
                FechaRegistro = fechaActual.ToString()

            };
        }

        private static StockFrsDTO ItemToDTOFRS(Stock stock) =>
        new StockFrsDTO
        {

            IdWhs = stock.IdWhs,
            WhsCode = stock.WhsCode,
            ShortWhsName = stock.ShortWhsName,
            OwnCode = stock.OwnCode,
            OwnName = stock.OwnName,
            IdItem = stock.IdItem,
            ItemCode = stock.ItemCode,
            ShortItemName = stock.ShortItemName,
            ItemDescription = stock.ItemDescription,
            QtyStock = stock.QtyStock,
            FechaRegistro = (DateTime.Now).ToString()

        };


        // GET: api/Stocks/5
        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetStockOwner")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStockOwner(string owner)
        {
            DAL dl = new DAL();
            List<Stock> stock = new List<Stock>();
            _logger.LogInformation("Ejecuta proceso " + "GetStockOwner");
            try
            {
                 stock = dl.GetStockOwner(owner);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex + ex.Message);
            }

            if (stock == null)
            {
                return NotFound();
            }
            return stock.ToList();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetStockFRS")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStockFRS(string ownerfrs)
        {
            DAL dl = new DAL();
            List<StockDTO> stock = new List<StockDTO>();
            _logger.LogInformation("Ejecuta proceso " + "GetStockOwnerFRS");
            try
            {
                 stock = dl.GetStockOwnerFRS(ownerfrs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }
            if (stock == null)
            {
                return NotFound();
            }
            return stock.ToList();    
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/PostStock")]
        public async Task<ActionResult<IEnumerable<Stock>>> PostStock(string owner)
        {
            _logger.LogInformation("Ejecuta proceso " + "PostStock");
            List<Stock> stocks = new List<Stock>();
            try
            {
                stocks = new LectorXML.leerXML().leerXMLOwner(owner);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }

            foreach (Stock stock in stocks)
            {
                Stock stock1 = new Stock();

                stock1.WhsCode = stock.WhsCode;
                stock1.ShortWhsName = stock.ShortWhsName;
                stock1.OwnCode = stock.OwnCode;
                stock1.OwnName = stock.OwnName;
                stock1.IdItem = stock.IdItem;
                stock1.ItemCode = stock.ItemCode;
                stock1.ShortItemName = stock.ShortItemName;
                stock1.ItemDescription = stock.ItemDescription;
                stock1.QtyStock = stock.QtyStock;
                stock1.QtyCicleCount = stock.QtyCicleCount;
                stock1.QtyReserved = stock.QtyReserved;
                stock1.QtyReceived = stock.QtyReceived;
                stock1.QtyStg = stock.QtyStg;
                stock1.QtyStgd = stock.QtyStgd;
                stock1.QtyStgr = stock.QtyStgr;
                stock1.QtyPendingPicking = stock.QtyPendingPicking;
                stock1.QtyTaskPicking = stock.QtyTaskPicking;
                stock1.QtyTaskSimulation = stock.QtyTaskSimulation;
                stock1.QtyHolded = stock.QtyHolded;
                stock1.QtyTruck = stock.QtyTruck;
                stock1.QtyTotal = stock.QtyTotal;
                stock1.QtyStgr = stock.QtyStgr;
                stock1.FechaRegistro = Convert.ToDateTime((DateTime.UtcNow).ToString("yyyy/MM/dd"));

                _context.Stock.Add(stock1);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.Message);
            }
            return Ok(new { message = "Registro correctro" });

        }
        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.IdWhs == id);
        }
    }
}
