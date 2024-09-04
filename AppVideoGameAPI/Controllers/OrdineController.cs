using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : BaseController
    {
        public OrdineController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

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
                            Quantita=Item.Quantita
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
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] CreaOrdineVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();

                Ordine NewOrder = new()
                {
                    Data = ObjSent.Data,
                    UtenteId = ObjSent.UtenteId,
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
    }
}
