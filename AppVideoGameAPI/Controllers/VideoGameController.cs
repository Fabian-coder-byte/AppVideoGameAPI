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
                List<Models.VideoGioco> VideoGiochi = [.. _context.VideoGiochi];

                foreach (Models.VideoGioco VideoGioco in VideoGiochi)
                {
                    DTO.VideoGioco videogioco = new()
                    {
                       Id = VideoGioco.Id,
                       CasaProduttriceId= VideoGioco.CasaProduttriceId,
                       DataRilascio=VideoGioco.DataRilascio,
                       Descrizione=VideoGioco.Descrizione,
                       Nome=VideoGioco.Nome,
                       
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
        [HttpGet]
        [Route("GetImageById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetImageById(int Id)
        {
            try
            {
                AllegatoVideoGioco AllegatoVideoGame = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.VideoGiocoId == Id) ?? throw new ArgumentException(Constants.ImmagineNotFound);
                    string codeImage = Convert.ToBase64String(AllegatoVideoGame.Content!);
                return Ok(codeImage);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("DeleteImagesVideoGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteImagesVideoGame(int Id)
        {
            try
            {
               List<AllegatoVideoGioco>  AllegatoVideoGames = [.. _context.AllegatiVideoGiochi.Where(a => a.VideoGiocoId == Id)];
                foreach(AllegatoVideoGioco allegato in AllegatoVideoGames)
                {
                    _context.AllegatiVideoGiochi.Remove(allegato);
                }
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(AllegatoVideoGames, new JsonSerializerSettings()
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
        [Route("DeleteImageByIdImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteImageByIdImage(int Id)
        {
            try
            {
               AllegatoVideoGioco AllegatoVideoGame = _context.AllegatiVideoGiochi.FirstOrDefault(a => a.Id == Id) ?? throw new ArgumentException(Constants.BadRequest);
                _context.AllegatiVideoGiochi.Remove(AllegatoVideoGame);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(AllegatoVideoGame, new JsonSerializerSettings()
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
        [Route("GetRequisitiPCById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetRequisitiPCById(int Id)
        {
                List<DTO.VideoGame.RequisitiPC> RequisitiPCList = [];
            try
            {
                if(!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                List<Models.RequisitiPC> RequisitiPCDatas = [.. _context.RequisitiPCs.Include(x=>x.LivelloRichiesto).Where(x => x.VideoGiocoId == Id)];
                foreach(Models.RequisitiPC RequisitiPCData in RequisitiPCDatas)
                {
                    DTO.VideoGame.RequisitiPC RequisitiPCObj = new()
                    {
                        Memory = RequisitiPCData.Memory,
                        DirectX = RequisitiPCData.DirectX,
                        AdditionalNotes = RequisitiPCData.AdditionalNotes,
                        OS = RequisitiPCData.OS,
                        Processor = RequisitiPCData.Processor,
                        Storage = RequisitiPCData.Storage,
                        Graphics = RequisitiPCData.Graphics,
                        LivelloRichiesto = RequisitiPCData.LivelloRichiesto!.Nome
                    };
                    RequisitiPCList.Add(RequisitiPCObj);
                }
             
                return Ok(JsonConvert.SerializeObject(RequisitiPCList, new JsonSerializerSettings()
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
        [Route("CreateRequisitiPC")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateRequisitiPC( RequisitiPCVM Obj)
        {
            try
            {
                if (!ModelState.IsValid) throw new  ArgumentException(Constants.BadRequest);
                Models.RequisitiPC RequsitiPCObj = new()
                {
                    
                    DirectX = Obj.DirectX,
                    Storage = Obj.Storage,
                    Processor = Obj.Processor,
                    OS = Obj.OS,
                    AdditionalNotes = Obj.AdditionalNotes,
                    Memory = Obj.Memory,
                    VideoGiocoId = Obj.VideoGiocoId,
                    LivelloRichiestoId=Obj.LivelloRichiestoId,
                    Graphics=Obj.Graphics,
                };
                _context.RequisitiPCs.Add(RequsitiPCObj);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(RequsitiPCObj, new JsonSerializerSettings()
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
        [Route("CreateLivelloPC")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateLivelloPC(string NomeLivello)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Models.LivelloRichiestoPC LivelloPCObj = new()
                {
                    Nome= NomeLivello
                };
                _context.LivelliRichiestiPC.Add(LivelloPCObj);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(LivelloPCObj, new JsonSerializerSettings()
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
        [Route("GetGenereGioco")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetGenereGioco(int Id)
        {
            List<DTO.VideoGame.ListaGeneriGioco> GeneriList = [];
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x=>x.Generi).FirstOrDefault(x=>x.Id==Id) ?? throw new ArgumentException(Constants.VideoGameNotFound);

                List<Models.Genere> GenereData = [.. VideoGioco.Generi!];
                foreach (Models.Genere Gen in GenereData)
                {
                    DTO.VideoGame.ListaGeneriGioco GenereGioco = new()
                    {
                      NomeGenere=Gen.Nome!
                    };
                    GeneriList.Add(GenereGioco);
                }

                return Ok(JsonConvert.SerializeObject(GeneriList, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }[HttpGet]
        [Route("GetAllGeneri")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllGeneri()
        {
            List<DTO.VideoGame.ListaGeneriGioco> GeneriList = [];
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);

                List<Models.Genere> GenereData = [.. _context.Generi.Include(x=>x.VideoGiochi)];
                foreach (Models.Genere Gen in GenereData)
                {
                    DTO.VideoGame.ListaGeneriGioco GenereGioco = new()
                    {
                      NomeGenere=Gen.Nome!,
                      Id=Gen.Id,
                    };
                    GenereGioco.VideoGiochi = [];
                    foreach (Models.VideoGioco el in Gen.VideoGiochi!)
                    {
                        GenereGioco.VideoGiochi!.Add(el.Nome!);
                    }
                    GeneriList.Add(GenereGioco);
                }
                return Ok(JsonConvert.SerializeObject(GeneriList, new JsonSerializerSettings()
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
        [Route("CreateGenere")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateGenere(string NomeGenere)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Genere GenereNew = new()
                {
                    Nome = NomeGenere,
                };
                _context.Generi.Add(GenereNew);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(GenereNew, new JsonSerializerSettings()
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
        [Route("AssociareGenereGioco")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AssociareGenereGioco(int GenereId,int GiocoId)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Genere Genere = _context.Generi.FirstOrDefault(x=>x.Id == GenereId) ?? throw new ArgumentException(Constants.BadRequest);
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x=>x.Generi).FirstOrDefault(x=>x.Id==GiocoId) ?? throw new ArgumentException(Constants.VideoGameNotFound);
                VideoGioco.Generi!.Add(Genere);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Genere, new JsonSerializerSettings()
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
