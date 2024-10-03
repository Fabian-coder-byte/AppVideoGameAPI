using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.Utilities;
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
    public class ConsoleController : BaseController
    {
        public ConsoleController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        #region [Console]
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.Console>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
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
        //Una Console Spacifica
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(List<DTO.Console>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                Models.Console Consoles = _context.Consoles.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArgumentException(Constants.ConsoleNotFound);

                DTO.Console result = new()
                {
                    Id = Consoles.Id,
                    Nome = Consoles.Nome!,
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
        //Crea Nuova Console
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(DTO.Console), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] ConsolePostVM ConsolePost)
        {
            try
            {
                if (!TryValidateModel(ConsolePost)) return BadRequest();
                Models.Console consoleCreated = _mapper.Map<Models.Console>(ConsolePost);
                _context.Consoles.Add(consoleCreated);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(consoleCreated, new JsonSerializerSettings()
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
        //Aggiorna Console
        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(DTO.Console), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update([FromBody] ConsolePostVM ConsolePost)
        {
            try
            {
                if (!TryValidateModel(ConsolePost)) return BadRequest();
                Models.Console ConsoleEdit = _mapper.Map<Models.Console>(ConsolePost);
                _context.Consoles.Update(ConsoleEdit);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ConsoleEdit, new JsonSerializerSettings()
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
        //Elimina Console
        [HttpGet]
        [Route("Delete")]
        [ProducesResponseType(typeof(List<DTO.Console>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                Models.Console ConsoleToRemove = _context.Consoles.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArgumentException(Constants.ConsoleNotFound);
                _context.Consoles.Remove(ConsoleToRemove);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ConsoleToRemove, new JsonSerializerSettings()
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
        #endregion
        #region [ModelloConsole]
        //tutti i modelli console di una console
        [HttpGet]
        [Route("GetAllModelli")]
        [ProducesResponseType(typeof(List<DTO.ModelloConsoleList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllModelli()
        {
            List<DTO.ModelloConsoleList> ModelliConsole = [];
            try
            {
                Models.Console ConsoleObj = _context.Consoles
                    .Include(x => x.ModelliConsoles)
                     .FirstOrDefault()
                     ?? throw new ArgumentException(Constants.ConsoleNotFound);

                foreach (var modello in ConsoleObj.ModelliConsoles!)
                {
                    DTO.ModelloConsoleList ModelloConsole = new()
                    {
                        Id = modello.Id,
                        Nome = modello.Nome,
                        ConsoleId=modello.ConsoleId,
                    };
                    ModelliConsole.Add(ModelloConsole);
                }

                return Ok(JsonConvert.SerializeObject(ModelliConsole, new JsonSerializerSettings()
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
        [Route("GetAllModelliConsole")]
        [ProducesResponseType(typeof(List<DTO.ModelloConsoleList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllModelliConsole(int consoleId)
        {
            List<DTO.ModelloConsoleList> ModelliConsole = [];
            try
            {
                Models.Console ConsoleObj = _context.Consoles
                    .Include(x => x.ModelliConsoles)
                     .Where(x => x.Id == consoleId)
                     .FirstOrDefault()
                     ?? throw new ArgumentException(Constants.ConsoleNotFound);

                foreach (ModelloConsole modello in ConsoleObj.ModelliConsoles!)
                {
                    DTO.ModelloConsoleList ModelloConsole = new()
                    {
                        Id = modello.Id,
                        Nome = modello.Nome,
                        ConsoleId=modello.ConsoleId
                    };
                    ModelliConsole.Add(ModelloConsole);
                }

                return Ok(JsonConvert.SerializeObject(ModelliConsole, new JsonSerializerSettings()
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
        //Aggiungi un modello ad una console
        [HttpGet]
        [Route("AddModelloToConsole")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddModelloToConsole(int idConsole, int idModello)
        {
            try
            {
                Models.Console Console = _context.Consoles.Include(x=>x.ModelliConsoles).FirstOrDefault(x => x.Id == idConsole)
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                Models.ModelloConsole ModelloConsole = _context.ModelliConsole.Include(x => x.VideoGiochi).FirstOrDefault(x => x.Id == idModello)
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                Console.ModelliConsoles!.Add(ModelloConsole);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ModelloConsole, new JsonSerializerSettings()
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
        //Crea Nuovo Modello
        [HttpPost]
        [Route("CreateModello")]
        [ProducesResponseType(typeof(DTO.Console), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateModello([FromBody] ConsoleModelloVM ConsoleModelloPost)
        {
            try
            {
                if (!TryValidateModel(ConsoleModelloPost)) return BadRequest();
                Models.ModelloConsole modelloCreated = new()
                {
                    Nome = ConsoleModelloPost.Nome,
                    ConsoleId = ConsoleModelloPost.ConsoleId,
                };
                _context.ModelliConsole.Add(modelloCreated);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(modelloCreated, new JsonSerializerSettings()
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

        //Aggiorna Modello
        [HttpPost]
        [Route("UpdateModello")]
        [ProducesResponseType(typeof(DTO.Console), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateModello([FromBody] ConsoleModelloVM ConsoleModelloPost)
        {
            try
            {
                if (!TryValidateModel(ConsoleModelloPost)) return BadRequest();
                ModelloConsole ModelloConsoleData = _context.ModelliConsole.FirstOrDefault(x=>x.Id == ConsoleModelloPost.ConsoleId) 
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                ModelloConsoleData.Nome = ConsoleModelloPost.Nome;
                ModelloConsoleData.ConsoleId = ConsoleModelloPost.ConsoleId;
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ConsoleModelloPost, new JsonSerializerSettings()
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
        [Route("DeleteModelloToConsole")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteModelloToConsole(int id)
        {
            try
            {
                //Models.Console Console = _context.Consoles.Include(x => x.ModelliConsoles).FirstOrDefault(x => x.Id == idConsole)
                //    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                Models.ModelloConsole ModelloConsole = _context.ModelliConsole.Include(x => x.VideoGiochi).FirstOrDefault(x => x.Id == id)
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                //Console.ModelliConsoles!.Remove(ModelloConsole);
                _context.ModelliConsole.Remove(ModelloConsole);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(ModelloConsole, new JsonSerializerSettings()
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
        #endregion
        #region [VideoGame]
        //Tutti i videogiochi di un modello console
        [HttpGet]
        [Route("GetAllVideoGame")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllVideoGame(int modelloConsoleId)
        {
            List<DTO.VideoGioco> results = [];
            try
            {
                Models.ModelloConsole ModelloConsole = _context.ModelliConsole
                     .Include(c => c.VideoGiochi)!
                     .ThenInclude(x => x.CasaProduttrice)
                    .Include(e => e.VideoGiochi)!
                    .ThenInclude(d => d.AllegatiVideoGiochi)
                     .Where(x => x.Id == modelloConsoleId)
                     .FirstOrDefault()
                     ?? throw new ArgumentException(Constants.ConsoleNotFound);

                foreach (Models.VideoGioco item in ModelloConsole.VideoGiochi!)
                {
                    DTO.VideoGioco Cons = new()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        DataRilascio = item.DataRilascio,
                        Descrizione = item.Descrizione,
                        CasaProduttrice = item.CasaProduttrice!.Nome,
                        ContentImage = item.AllegatiVideoGiochi?.FirstOrDefault()?.Content
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
        //tutti i videogiochi non associati ad un determinato modello console
        [HttpGet]
        [Route("GetAllNoVideoGame")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllNoVideoGame(int modelloConsoleId)
        {
            List<DTO.VideoGioco> results = [];
            try
            {
                Models.ModelloConsole ConsoleFind = _context.ModelliConsole
                     .Include(c => c.VideoGiochi)!
                     .ThenInclude(x => x.CasaProduttrice)
                     .Where(x => x.Id == modelloConsoleId)
                     .FirstOrDefault()
                     ?? throw new ArgumentException(Constants.ConsoleNotFound);
                List<Models.VideoGioco> VideoGiochi = [.. _context.VideoGiochi
                 .Include(x => x.CasaProduttrice)
                 .Where(x => !x.Consoles!.Any(c => c.Id == modelloConsoleId))];

                foreach (Models.VideoGioco item in VideoGiochi)
                {
                    DTO.VideoGioco Cons = new()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        DataRilascio = item.DataRilascio,
                        Descrizione = item.Descrizione,
                        CasaProduttrice = item.CasaProduttrice!.Nome,
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
        //aggiungi un videogioco ad un modello console
        [HttpGet]
        [Route("AddVideoGameConsole")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddVideoGameConsole(int idModelloConsole, int idVideoGioco)
        {
            try
            {
                Models.VideoGioco VideoGioco = _context.VideoGiochi.FirstOrDefault(x => x.Id == idVideoGioco)
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                Models.ModelloConsole Console = _context.ModelliConsole.Include(x => x.VideoGiochi).FirstOrDefault(x => x.Id == idModelloConsole)
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                Console.VideoGiochi!.Add(VideoGioco);
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
        //elimina una associazione tra modello e videogioco
        [HttpGet]
        [Route("DeleteVideoGameConsole")]
        [ProducesResponseType(typeof(List<DTO.VideoGioco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteVideoGameConsole(int idModelloConsole, int idVideoGioco)
        {
            try
            {
                Models.VideoGioco VideoGioco = _context.VideoGiochi.FirstOrDefault(x => x.Id == idVideoGioco)
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                Models.ModelloConsole Console = _context.ModelliConsole.Include(x => x.VideoGiochi).FirstOrDefault(x => x.Id == idModelloConsole)
                    ?? throw new ArgumentException(Constants.ConsoleNotFound);
                Console.VideoGiochi!.Remove(VideoGioco);
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
        #endregion

    }
}
 