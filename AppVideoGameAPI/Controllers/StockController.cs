using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO.Stocks;
using AppVideoGameAPI.Utilities;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PoolBookingApp.Models;

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
                        NomeVideoGioco = StockItem.VideoGioco?.Nome!,
                        NomeConsole = StockItem.Console?.Nome!,
                        FormatoVideoGioco = StockItem.Formato?.Nome!,
                        Prezzo = StockItem.Prezzo,
                        QuantitaRimanenti = StockItem.Quantita,
                    };
                    AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == StockItem.VideoGioco!.Id!);
                    if (allegatoVideoGioco != null)
                        stock.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
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
        public IActionResult Create([FromBody] AddStockVideoGame stockSent)
        {
            try
            {
                if (!TryValidateModel(stockSent)) return BadRequest();

                Models.Stock stock = new()
                {
                    ConsoleId = stockSent.ConsoleId,
                    FormatoGiocoId=stockSent.FormatoGiocoId,
                    Prezzo=stockSent.Prezzo,
                    Quantita=stockSent.Quantita,
                    VideoGiocoId=stockSent.VideoGiocoId,
                };
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

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(DatiVideoGame), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                Models.Stock StockVideoGame = _context.Stocks.
                    Include(x => x.Console).
                    Include(x => x.VideoGioco).
                    ThenInclude(a=>a.CasaProduttrice).
                    Include(x=>x.VideoGioco)
                    .ThenInclude(a=>a.AllegatiVideoGiochi)
                    .Include(x => x.Formato).FirstOrDefault(x => x.VideoGiocoId == id) ?? throw new ArgumentException(Constants.VideoGameNotFound);

                DatiVideoGame VideoGioco = new()
                {
                    NomeVideoGioco=StockVideoGame.VideoGioco.Nome,
                    CasaProduttrice=StockVideoGame.VideoGioco.CasaProduttrice.Nome,
                    NomeConsole=StockVideoGame.Console.Nome,
                    Prezzo=StockVideoGame.Prezzo,
                    QuantitaRimanenti=StockVideoGame.Quantita,
                    FormatoVideoGioco=StockVideoGame.Formato.Nome,
                    DescrizioneGioco=StockVideoGame.VideoGioco.Descrizione
                };
                List<AllegatoVideoGioco>? allegatiVideoGiochi = _context.AllegatiVideoGiochi.Where(a => a.VideoGiocoId == StockVideoGame.Id).ToList();
                if (allegatiVideoGiochi.Count != 0)
                {
                    VideoGioco.CodeImages = [];
                    foreach (var el in allegatiVideoGiochi)
                    {
                        VideoGioco.CodeImages.Add(Convert.ToBase64String(el.Content!));
                    }
                }
                return Ok(JsonConvert.SerializeObject(VideoGioco, new JsonSerializerSettings()
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
