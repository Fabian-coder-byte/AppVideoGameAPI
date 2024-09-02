using AppVideoGameAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
