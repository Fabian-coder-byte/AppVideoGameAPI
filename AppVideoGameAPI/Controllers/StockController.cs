using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO.Stocks;
using AppVideoGameAPI.Models;
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
                List<Models.StockVideoGioco> Stocks = [.. _context.Stocks.
                    Include(x=>x.Console).
                    Include(x=>x.VideoGioco).
                    Include(x=>x.Formato)];
                foreach (Models.StockVideoGioco StockItem in Stocks)
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
        [HttpGet]
        [Route("GetAllSearchByName")]
        [ProducesResponseType(typeof(List<VideoGameMenu>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllSearchByName(string? nome,int ordinamentoId,int tipoConsoleId,int tipoFormatoId)
        {
            List<VideoGameMenu> results = [];
            try
            {
                //Ordinamento
                //1 Ordine Crescente
                //2 Ordine Decrescente
                //3 Ultime Uscite
                //4 Prime Uscite
                List<Models.StockVideoGioco> Stocks = [];
                switch (ordinamentoId)
                {
                    case 1:
                        Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato).OrderBy(x=>x.VideoGioco.Nome)];
                        break;
                    case 2:
                        Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato).OrderByDescending(x=>x.VideoGioco.Nome)];
                        break;
                    case 3:
                        Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato).OrderBy(x=>x.VideoGioco.DataRilascio)];
                        break;
                    case 4:
                        Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato).OrderByDescending(x=>x.VideoGioco.DataRilascio)];
                        break;

                }
               
                if (String.IsNullOrEmpty(nome))
                {
                    Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato)];
                }
                else
                {
                    Stocks = [.._context.Stocks
                         .Include(x => x.Console)
                         .Include(x => x.VideoGioco)
                         .Include(x => x.Formato)
                         .Where(a => a.VideoGioco!.Nome!.Contains(nome))];
                }

                foreach (Models.StockVideoGioco StockItem in Stocks)
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

                Models.StockVideoGioco stock = new()
                {
                    ConsoleId = stockSent.ConsoleId,
                    FormatoGiocoId = stockSent.FormatoGiocoId,
                    Prezzo = stockSent.Prezzo,
                    Quantita = stockSent.Quantita,
                    VideoGiocoId = stockSent.VideoGiocoId,
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
                Models.StockVideoGioco StockVideoGame = _context.Stocks.
                    Include(x => x.Console).
                    Include(x => x.VideoGioco).
                    ThenInclude(a => a.CasaProduttrice).
                    Include(x => x.VideoGioco)
                    .ThenInclude(a => a.AllegatiVideoGiochi)
                    .Include(x => x.Formato).FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException(Constants.VideoGameNotFound);

                DatiVideoGame VideoGioco = new()
                {
                    NomeVideoGioco = StockVideoGame.VideoGioco.Nome,
                    CasaProduttrice = StockVideoGame.VideoGioco.CasaProduttrice.Nome,
                    NomeConsole = StockVideoGame.Console.Nome,
                    Prezzo = StockVideoGame.Prezzo,
                    QuantitaRimanenti = StockVideoGame.Quantita,
                    FormatoVideoGioco = StockVideoGame.Formato.Nome,
                    DescrizioneGioco = StockVideoGame.VideoGioco.Descrizione,
                    Id = id,
                    DataRilascio = StockVideoGame.VideoGioco.DataRilascio

                };
                AllegatoVideoGioco? allegatiVideoGiochi = _context.AllegatiVideoGiochi.Where(a => a.VideoGiocoId == StockVideoGame.VideoGiocoId && a.TipoAllegatoId == 5).FirstOrDefault();
                if (allegatiVideoGiochi != null)
                {
                    VideoGioco.CodeImage = Convert.ToBase64String(allegatiVideoGiochi.Content!);
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

        [HttpGet]
        [Route("GetAllImagesGame")]
        [ProducesResponseType(typeof(List<VideoGameMenu>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllImagesGame(int id)
        {
            try
            {
                List<string> results = [.. _context.Stocks
                    .Include(x=>x.VideoGioco)
                    .ThenInclude(x=>x.AllegatiVideoGiochi)
                     .Where(a => a.Id == id)
                     .SelectMany(x => x.VideoGioco!.AllegatiVideoGiochi!
                         .Where(allegato => allegato.TipoAllegatoId == 2)
                         .Select(allegato => Convert.ToBase64String(allegato.Content!))
                     )];
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

        [HttpGet]
        [Route("GetTrailerGame")]
        [ProducesResponseType(typeof(List<VideoGameMenu>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTrailerGame(int id)
        {
            try
            {
                string? result = _context.Stocks
                    .Include(x => x.VideoGioco)
                    .ThenInclude(x => x.AllegatiVideoGiochi)
                     .Where(a => a.Id == id)
                     .SelectMany(x => x.VideoGioco!.AllegatiVideoGiochi!
                         .Where(allegato => allegato.TipoAllegatoId == 6)
                         .Select(allegato => Convert.ToBase64String(allegato.Content!))
                     ).FirstOrDefault();
                return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings()
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
