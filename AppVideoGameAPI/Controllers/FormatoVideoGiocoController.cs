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
    public class FormatoVideoGiocoController : BaseController
    {
        public FormatoVideoGiocoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.FormatoVideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<DTO.FormatoVideoGioco> results = [];
            try
            {
                List<Models.FormatoGioco> FormatoGiochi = [.. _context.Formati];

                foreach (Models.FormatoGioco Formato in FormatoGiochi)
                {
                    DTO.FormatoVideoGioco FormatoObj = new()
                    {
                        Id = Formato.Id,
                        Nome = Formato.Nome!,
                    };
                    results.Add(FormatoObj);
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
