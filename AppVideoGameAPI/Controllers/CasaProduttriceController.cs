using AppVideoGameAPI.Data;
using AppVideoGameAPI.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaProduttriceController : BaseController
    {
        public CasaProduttriceController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.CasaProduttrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
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
        [Route("GetById")]
        [ProducesResponseType(typeof(List<DTO.CasaProduttrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                Models.CasaProduttrice CasaProduttrice = _context.CaseProduttrici.Where(x=>x.Id==id).FirstOrDefault() ?? throw new ArgumentException(Constants.CasaProduttriceNotFound);

                DTO.CasaProduttrice result = new()
                    {
                        Id = CasaProduttrice.Id,
                        Nome = CasaProduttrice.Nome,
                    };
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

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(DTO.CasaProduttrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] DTO.CasaProduttrice casaProduttriceSent)
        {
            try
            {
                if (!TryValidateModel(casaProduttriceSent)) return BadRequest();

                Models.CasaProduttrice CasaProduttriceCreated = _mapper.Map<Models.CasaProduttrice>(casaProduttriceSent);
                _context.CaseProduttrici.Add(CasaProduttriceCreated);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(CasaProduttriceCreated, new JsonSerializerSettings()
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
        [Route("Delete")]
        [ProducesResponseType(typeof(List<DTO.CasaProduttrice>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                Models.CasaProduttrice CasaProduttrice = _context.CaseProduttrici.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArgumentException(Constants.CasaProduttriceNotFound);
                _context.CaseProduttrici.Remove(CasaProduttrice);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(CasaProduttrice,new JsonSerializerSettings()
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
        [Route("Update")]
        [ProducesResponseType(typeof(DTO.CasaProduttrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] DTO.CasaProduttrice casaProduttriceSent)
        {
            try
            {
                if (!TryValidateModel(casaProduttriceSent)) return BadRequest();

                Models.CasaProduttrice CasaProduttriceCreated = _mapper.Map<Models.CasaProduttrice>(casaProduttriceSent);
                _context.CaseProduttrici.Update(CasaProduttriceCreated);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(CasaProduttriceCreated, new JsonSerializerSettings()
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
