using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO.Recensione;
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
    public class RecensioneController : BaseController
    {
        public RecensioneController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.Recensione.RecensioneList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<DTO.Recensione.RecensioneList> results = [];
            try
            {
                List<Models.Recensione> RecensioniList = [.. _context.Recensioni.Include(x=>x.VideoGioco).Include(x=>x.Utente)];

                foreach (Models.Recensione Rec in RecensioniList)
                {
                    DTO.Recensione.RecensioneList RecensioneObj = new()
                    {
                       Data = Rec.Data,
                       Descrizione = Rec.Descrizione,
                       EmailUtente=Rec.Utente!.Email!,
                       NomeCognomeUtente=$"{Rec.Utente.Nome} {Rec.Utente.Cognome}" ,
                       NomeVideoGioco=Rec.VideoGioco!.Nome!,
                       Voto=Rec.Voto
                    };
                    results.Add(RecensioneObj);
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
        public IActionResult Create([FromBody]  DTO.Recensione.RecensioneCreate ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();

                Models.Recensione Recensione = _mapper.Map<Models.Recensione>(ObjSent);
                _context.Recensioni.Add(Recensione);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Recensione, new JsonSerializerSettings()
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
