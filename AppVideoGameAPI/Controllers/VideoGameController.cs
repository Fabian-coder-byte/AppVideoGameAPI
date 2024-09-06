using AppVideoGameAPI.Data;
using AppVideoGameAPI.DTO;
using AppVideoGameAPI.DTO.VideoGame;
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

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : BaseController
    {
        public VideoGameController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.CasaProduttrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<DTO.VideoGioco> results = [];
            try
            {
                IEnumerable<Models.VideoGioco> VideoGiochi = _context.VideoGiochi.AsEnumerable();

                foreach (Models.VideoGioco VideoGioco in VideoGiochi)
                {
                    DTO.VideoGioco videogioco = new()
                    {
                       Id = VideoGioco.Id,
                       CasaProduttriceId= VideoGioco.CasaProduttriceId,
                       DataRilascio=VideoGioco.DataRilascio,
                       Descrizione=VideoGioco.Descrizione,
                       Nome=VideoGioco.Nome
                    };
                    results.Add(videogioco);
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
        public IActionResult Create([FromBody] DTO.VideoGame.VideoGame ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                Models.VideoGioco NewVideoGame = new()
                {
                    CasaProduttriceId=ObjSent.CasaProduttriceId,
                    DataRilascio=ObjSent.DataRilascio,
                    Descrizione = ObjSent.Descrizione,
                    Nome=ObjSent.Nome
                };
                _context.VideoGiochi.Add(NewVideoGame);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(NewVideoGame, new JsonSerializerSettings()
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
        [Route("AddAllegato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddAllegato(VideoGameAllegatoVM ObjSent)
        {
            try
            {

                if (!TryValidateModel(ObjSent)) return BadRequest();
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x=>x.AllegatiVideoGiochi).
                    FirstOrDefault(x=>x.Id==ObjSent.VideoGameId) 
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                foreach(IFormFile el in ObjSent.FileCaricato)
                {
                    using BinaryReader reader = new(el.OpenReadStream());
                    VideoGioco.AllegatiVideoGiochi.Add(new()
                    {
                        Content= reader.ReadBytes((int)el.Length),
                        NomeFile = el.FileName,
                        VideoGiocoId=VideoGioco.Id,
                    });
                }
                _context.SaveChanges();
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
