using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO.Ordine;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.Utilities;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PoolBookingApp.Models;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : BaseController
    {
        protected readonly UserManager<DataUser> _userManager;
        public OrdineController(ApplicationDbContext context, IMapper mapper, UserManager<DataUser> userManager) : base(context, mapper)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<DTO.Ordine.OrdineList> results = [];
            try
            {
                List<Models.Ordine> Ordini = [..
                    _context.Ordini.
                    Include(x=>x.DataUser)
                   .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Console)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Formato)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.VideoGioco)
                    ];

                foreach (Models.Ordine Ord in Ordini)
                {
                    DTO.Ordine.OrdineList Ordine = new()
                    {
                        Email = Ord.DataUser!.Email!,
                        NomeCgnome = $"{Ord.DataUser.Nome} {Ord.DataUser.Cognome}",
                        DataOrdine = Ord.Data,
                        Items = []
                    };
                    foreach (Models.ItemOrdine Item in Ord.ItemOrdini)
                    {
                        Ordine.Items.Add(new()
                        {
                            ConsoleGioco = Item.Stock.Console.Nome,
                            FormatoGioco = Item.Stock.Formato.Nome,
                            NomeVideogioco = Item.Stock.VideoGioco.Nome,
                            Quantita = Item.Quantita,
                            Prezzo = Item.Prezzo
                        });
                    }
                    results.Add(Ordine);
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
        [Route("GetAllByUserId")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllByUserId(string userId)
        {
            List<DTO.Ordine.OrdineListUtente> results = [];
            try
            {
                List<Models.Ordine> Ordini = [..
                    _context.Ordini.
                    Include(x=>x.DataUser)
                   .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Console)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Formato)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.VideoGioco)
                            .Where(x=>x.UtenteId==userId && x.Data!=null)
                    ];

                foreach (Models.Ordine Ord in Ordini)
                {
                    DTO.Ordine.OrdineListUtente Ordine = new()
                    {
                        DataOrdine = Ord.Data,
                        Items = [],
                        OrderId = Ord.Id
                    };
                    foreach (Models.ItemOrdine Item in Ord.ItemOrdini)
                    {
                        OrdineItem OrdineItem = new()
                        {
                            ConsoleGioco = Item.Stock.Console.Nome,
                            FormatoGioco = Item.Stock.Formato.Nome,
                            NomeVideogioco = Item.Stock.VideoGioco.Nome,
                            Quantita = Item.Quantita,
                            Prezzo = Item.Stock.Prezzo,
                            ItemId = Item.Id

                        };
                        AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Item.Stock.VideoGiocoId);
                        if (allegatoVideoGioco != null)
                            OrdineItem.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
                        Ordine.Items.Add(OrdineItem);
                    }
                    results.Add(Ordine);
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
        [Route("GetGameById")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetGameById(string userId, int gameId)
        {
            DTO.Ordine.OrdineListUtente OrdineObj = null;
            try
            {
                Models.Ordine? Ordine =
                    _context.Ordini.
                    Include(x => x.DataUser)
                   .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Console)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Formato)
                    .Include(o => o.ItemOrdini)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.VideoGioco)
                            .Where(x => x.UtenteId == userId && x.ItemOrdini!.Any(s => s.StockId == gameId)).FirstOrDefault();
                if (Ordine != null)
                {
                    OrdineObj = new()
                    {
                        DataOrdine = Ordine.Data,
                        Items = [],
                        OrderId = Ordine.Id
                    };
                    foreach (Models.ItemOrdine Item in Ordine.ItemOrdini!)
                    {
                        OrdineItem OrdineItem = new()
                        {
                            ConsoleGioco = Item.Stock.Console.Nome,
                            FormatoGioco = Item.Stock.Formato.Nome,
                            NomeVideogioco = Item.Stock.VideoGioco.Nome,
                            Quantita = Item.Quantita,
                            Prezzo = Item.Stock.Prezzo,
                            ItemId = Item.Id

                        };
                        AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Item.Stock.VideoGiocoId);
                        if (allegatoVideoGioco != null)
                            OrdineItem.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
                        OrdineObj.Items.Add(OrdineItem);
                    }
                }
                return Ok(JsonConvert.SerializeObject(OrdineObj, new JsonSerializerSettings()
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreaOrdineVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                DataUser Utente = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == ObjSent.UtenteId)
                    ?? throw new ArgumentException(Constants.UtenteNontrovato);
                Ordine NewOrder = new()
                {
                    Data = ObjSent.Data,
                    DataUser = Utente,
                    MetodoPagamentoId = ObjSent.MetodoPagamentoId,

                };
                CarrelloOrdine CarrelloOrdine = await _context.CarrelloOrdini.Include(x => x.ItemsCarrello).FirstOrDefaultAsync(x => x.UtenteId == Utente.Id)
                    ?? throw new ArgumentException(Constants.CarrelloNotFound);
                MetodoPagamento? MetodoPagamento = await _context.MetodoPagamento.FirstOrDefaultAsync(x => x.Id == ObjSent.MetodoPagamentoId);
                double TotaleSpesa = CarrelloOrdine.ItemsCarrello!.Sum(x => x.Quantita * x.Prezzo);
                double saldoDisponibile = MetodoPagamento?.SaldoDisponibile ?? Utente.SaldoDisponibile;
                if (saldoDisponibile < TotaleSpesa)
                {
                    throw new ArgumentException(Constants.DenaroInsufficente);
                }

                if (MetodoPagamento != null)
                {
                    if (MetodoPagamento.DataScadenza < DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentException(Constants.CartaScaduta);
                    MetodoPagamento.SaldoDisponibile -= TotaleSpesa;
                }
                else
                {
                    Utente.SaldoDisponibile -= TotaleSpesa;
                }
                NewOrder.ItemOrdini = [];
                foreach (ItemCarrello itemCar in CarrelloOrdine.ItemsCarrello!)
                {
                    bool isStockAvailable = await _context.Stocks
                    .Where(x => x.Id == itemCar.StockId)
                    .AnyAsync(x => x.Quantita >= itemCar.Quantita);
                    if (!isStockAvailable)
                    {
                        throw new ArgumentException(Constants.QuantitaInsufficente);
                    }
                    NewOrder.ItemOrdini.Add(new()
                    {
                        Quantita = itemCar.Quantita,
                        StockId = itemCar.StockId,
                        Ordine = NewOrder,
                        Prezzo = itemCar.Prezzo
                    });
                }
                _context.Ordini.Add(NewOrder);
                foreach (ItemCarrello item in CarrelloOrdine.ItemsCarrello.ToList())
                {
                    _context.ItemsCarrello.Remove(item);
                }
                CarrelloOrdine.ItemsCarrello.Clear();
                await _context.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(NewOrder, new JsonSerializerSettings()
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
        [Route("AddItemToCarrello")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddItemToCarrello([FromBody] AddOrdineCarrelloVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                StockVideoGioco StockVideoGame = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == ObjSent.StockId)
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                DataUser Utente = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == ObjSent.UtenteId) ?? throw new ArgumentException(Constants.UtenteNontrovato);
                CarrelloOrdine? CarrelloGiaPresente = await _context.CarrelloOrdini.Include(x => x.ItemsCarrello).FirstOrDefaultAsync(x => x.UtenteId == Utente.Id);
                if (CarrelloGiaPresente != null)
                {
                    ItemCarrello? VideoGamePresente = CarrelloGiaPresente.ItemsCarrello!.FirstOrDefault(x => x.StockId == StockVideoGame.Id);
                    if (VideoGamePresente != null)
                    {
                        VideoGamePresente.Quantita += ObjSent.Quantita;
                    }
                    else
                    {
                        CarrelloGiaPresente.ItemsCarrello!.Add(new()
                        {
                            StockId = ObjSent.StockId,
                            Quantita = ObjSent.Quantita,
                            Prezzo = StockVideoGame.Prezzo,
                        });
                    }
                }
                else
                {
                    CarrelloOrdine NewCarrello = new()
                    {
                        DataUser = Utente,
                    };
                    NewCarrello.ItemsCarrello = [];
                    NewCarrello.ItemsCarrello.Add(new()
                    {
                        Quantita = ObjSent.Quantita,
                        StockId = StockVideoGame.Id,
                        Prezzo = StockVideoGame.Prezzo,
                        CarrelloOrdine = NewCarrello,
                    });
                    _context.CarrelloOrdini.Add(NewCarrello);
                }
                await _context.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(ObjSent, new JsonSerializerSettings()
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
        [Route("RemoveItemCarrello")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RemoveItemCarrello(int CarrelloId, int ItemId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                CarrelloOrdine CarrelloOrdine = _context.CarrelloOrdini.Include(x => x.ItemsCarrello).FirstOrDefault(x => x.Id == CarrelloId)
                    ?? throw new ArgumentException(Constants.BadRequest);
                ItemCarrello Itemcarrello = CarrelloOrdine.ItemsCarrello!.FirstOrDefault(x => x.Id == ItemId)
                    ?? throw new ArgumentException(Constants.BadRequest);
                CarrelloOrdine.ItemsCarrello!.Remove(Itemcarrello);
                _context.ItemsCarrello.Remove(Itemcarrello);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Itemcarrello, new JsonSerializerSettings()
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
        [Route("GetAllCarrelloByUserId")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCarrelloByUserId(string userId)
        {
            try
            {
                Models.CarrelloOrdine? CarrelloOrdine =
                    _context.CarrelloOrdini.
                    Include(x => x.DataUser)
                   .Include(o => o.ItemsCarrello)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Console)
                    .Include(o => o.ItemsCarrello)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.Formato)
                    .Include(o => o.ItemsCarrello)!
                        .ThenInclude(io => io.Stock)
                            .ThenInclude(s => s.VideoGioco)
                            .Where(x => x.UtenteId == userId).FirstOrDefault();
                DTO.Ordine.CarrelloList CarrelloObj = new()
                {
                    CarrelloId = CarrelloOrdine != null ? CarrelloOrdine.Id : 0,
                    Items = []
                };
                if (CarrelloOrdine != null)
                {
                    foreach (Models.ItemCarrello Item in CarrelloOrdine.ItemsCarrello!)
                    {
                        OrdineItem OrdineItem = new()
                        {
                            ConsoleGioco = Item.Stock.Console.Nome,
                            FormatoGioco = Item.Stock.Formato.Nome,
                            NomeVideogioco = Item.Stock.VideoGioco.Nome,
                            Quantita = Item.Quantita,
                            Prezzo = Item.Stock.Prezzo,
                            ItemId = Item.Id,
                        };
                        AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Item.Stock.VideoGiocoId);
                        if (allegatoVideoGioco != null)
                            OrdineItem.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
                        CarrelloObj.Items.Add(OrdineItem);
                    }
                }

                return Ok(JsonConvert.SerializeObject(CarrelloObj, new JsonSerializerSettings()
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
