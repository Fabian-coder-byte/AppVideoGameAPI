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
                            Quantita = Item.Quantita
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
                        Items = []
                    };
                    foreach (Models.ItemOrdine Item in Ord.ItemOrdini)
                    {
                        OrdineItem OrdineItem = new()
                        {
                            ConsoleGioco = Item.Stock.Console.Nome,
                            FormatoGioco = Item.Stock.Formato.Nome,
                            NomeVideogioco = Item.Stock.VideoGioco.Nome,
                            Quantita = Item.Quantita,
                            Prezzo=Item.Stock.Prezzo,

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
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreaOrdineVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                DataUser? Utente = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == ObjSent.UtenteId);
                Ordine NewOrder = new()
                {
                    Data = ObjSent.Data,
                    DataUser = Utente,
                };
                NewOrder.ItemOrdini = [];
                foreach (ItemOrdineVM Ord in ObjSent.Items)
                {
                    NewOrder.ItemOrdini.Add(new()
                    {
                        Quantita = Ord.Quantita,
                        StockId = Ord.StockId,
                        Ordine = NewOrder,
                    });
                }
                _context.Ordini.Add(NewOrder);
                _context.SaveChanges();
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

        [HttpGet]
        [Route("CreateOrdinazione")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  IActionResult CreateOrdinazione(int OrdineId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                Ordine Ordine = _context.Ordini.FirstOrDefault(x=>x.Id == OrdineId) ?? throw new ArgumentException("Errore");
                Ordine.Data = DateTime.Today;
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Ordine, new JsonSerializerSettings()
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
        [Route("CarrelloOrdine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CarrelloOrdine([FromBody] AddOrdineCarrelloVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                DataUser? Utente = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == ObjSent.UtenteId);
                Ordine? CarrelloGiaPresente = _context.Ordini.Include(x=>x.ItemOrdini).FirstOrDefault(x => x.DataUser == Utente && x.Data == null);
                if (CarrelloGiaPresente != null)
                {
                    ItemOrdine? item = CarrelloGiaPresente.ItemOrdini!.FirstOrDefault(x => x.StockId == ObjSent.StockId);
                    if (item != null) {
                        item.Quantita++;
                    }
                    else
                    {
                        CarrelloGiaPresente.ItemOrdini!.Add(new()
                        {
                            StockId = ObjSent.StockId,
                            Quantita = ObjSent.Quantita,
                        });
                    }
                  
                }
                else
                {
                    Ordine NewOrder = new()
                    {
                        DataUser = Utente,
                    };
                    NewOrder.ItemOrdini = [];
                    NewOrder.ItemOrdini.Add(new()
                    {
                        Quantita = ObjSent.Quantita,
                        StockId = ObjSent.StockId,
                        Ordine = NewOrder,
                    });
                    _context.Ordini.Add(NewOrder);
                }
                _context.SaveChanges();
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
        public  IActionResult RemoveItemCarrello(int OrdineId,int ItemId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                Ordine? Ordine = _context.Ordini.Include(x => x.ItemOrdini).FirstOrDefault(x => x.Id == OrdineId) ?? throw new ArgumentException(Constants.BadRequest);
                ItemOrdine ItemOrdine = Ordine.ItemOrdini!.Where(x => x.Id == ItemId).FirstOrDefault() ?? throw new ArgumentException(Constants.BadRequest);
                _context.ItemOrdini.Remove(ItemOrdine);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ItemOrdine, new JsonSerializerSettings()
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
            //List<OrdineItem> Results = [];
            try
            {
                Models.Ordine Ordine =
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
                            .Where(x => x.UtenteId == userId && x.Data == null).FirstOrDefault()
                            ?? throw new ArgumentException(Constants.BadRequest);

                DTO.Ordine.OrdineListUtente OrdineObj = new()
                {
                    DataOrdine = Ordine.Data,
                    OrderId=Ordine.Id,
                    Items = []
                };
                foreach (Models.ItemOrdine Item in Ordine.ItemOrdini!)
                {
                    OrdineItem OrdineItem = new()
                    {
                        ConsoleGioco = Item.Stock.Console.Nome,
                        FormatoGioco = Item.Stock.Formato.Nome,
                        NomeVideogioco = Item.Stock.VideoGioco.Nome,
                        Quantita = Item.Quantita,
                        Prezzo=Item.Stock.Prezzo,
                        ItemId = Item.Id,
                        OrderId=Item.OrdineId,

                    };
                    AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Item.Stock.VideoGiocoId);
                    if (allegatoVideoGioco != null)
                        OrdineItem.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
                    OrdineObj.Items.Add(OrdineItem);
                }

                //foreach (Models.ItemOrdine Item in Ordine.ItemOrdini)
                //{
                //    OrdineItem OrdineItem = new()
                //    {
                //        ConsoleGioco = Item.Stock.Console.Nome,
                //        FormatoGioco = Item.Stock.Formato.Nome,
                //        NomeVideogioco = Item.Stock.VideoGioco.Nome,
                //        Quantita = Item.Quantita,
                //        Prezzo=Item.Stock.Prezzo,
                //        ItemId= Item.Id,
                //        OrderId=Item.OrdineId

                //    };
                //    AllegatoVideoGioco? allegatoVideoGioco = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Item.Stock.VideoGiocoId);
                //    if (allegatoVideoGioco != null)
                //        OrdineItem.CodeImage = Convert.ToBase64String(allegatoVideoGioco.Content!);
                //    Results.Add(OrdineItem);
                //}
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
    }
}
