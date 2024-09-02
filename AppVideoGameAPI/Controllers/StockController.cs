using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO.Stocks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : BaseController
    {
        public StockController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<VideoGameMenu>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<VideoGameMenu> results = [];
            try
            {
                List<Models.Stock> Stocks = [.. _context.Stocks.
                    Include(x=>x.Console).
                    Include(x=>x.VideoGioco).
                    Include(x=>x.Formato)];
                foreach (Models.Stock StockItem in Stocks)
                {
                    VideoGameMenu stock = new()
                    {
                        Id = StockItem.Id,
                        NomeVideoGioco=StockItem.VideoGioco?.Nome!,
                       NomeConsole = StockItem.Console?.Nome!,
                       FormatoVideoGioco=StockItem.Formato?.Nome!,
                       Prezzo=StockItem.Prezzo,
                       QuantitaRimanenti=StockItem.Quantita,
                    };
                    results.Add(stock);
                }
                return Ok(JsonConvert.SerializeObject(results, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(VideoGameMenu), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] VideoGameMenu stockSent)
        {
            try
            {
                if (!TryValidateModel(stockSent)) return BadRequest();
                
                Models.Stock stock = _mapper.Map<Models.Stock>(stockSent);
                _context.Stocks.Add(stock);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(stock, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

    }
}
