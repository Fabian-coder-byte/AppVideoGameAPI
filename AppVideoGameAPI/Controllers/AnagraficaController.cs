using AppVideoGameAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaController : BaseController
    {
        public AnagraficaController(ApplicationDbContext context,IMapper mapper) : base(context,mapper)
        {
        }

        [HttpGet]
        [Route("GetCaseProduttrici")]
        [ProducesResponseType(typeof(List<DTO.CasaProduttrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetData()
        {
            List<DTO.CasaProduttrice> results = [];
            try
            {
                IEnumerable<Models.CasaProduttrice> CaseProduttrici = _context.CaseProduttrici.AsEnumerable();

                foreach (Models.CasaProduttrice CasaProduttrice in CaseProduttrici)
                {
                    DTO.CasaProduttrice casaPr = new()
                    {
                        Id = CasaProduttrice.Id,
                        Nome = CasaProduttrice.Nome,
                    };
                    results.Add(casaPr);
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
        [Route("GetAllConsole")]
        [ProducesResponseType(typeof(List<DTO.Console>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllConsole()
        {
            List<DTO.CasaProduttrice> results = [];
            try
            {
                IEnumerable<Models.Console> Consoles = _context.Consoles.AsEnumerable();

                foreach (Models.Console Console in Consoles)
                {
                    DTO.CasaProduttrice Cons = new()
                    {
                        Id = Console.Id,
                        Nome = Console.Nome,
                    };
                    results.Add(Cons);
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
