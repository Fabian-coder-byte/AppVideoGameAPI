﻿using AppVideoGameAPI.Data;
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
                List<Models.VideoGioco> VideoGiochi = [.. _context.VideoGiochi.Include(x => x.CasaProduttrice)];

                foreach (Models.VideoGioco VideoGioco in VideoGiochi)
                {
                    DTO.VideoGioco videogioco = new()
                    {
                        Id = VideoGioco.Id,
                        CasaProduttrice = VideoGioco.CasaProduttrice!.Nome,
                        DataRilascio = VideoGioco.DataRilascio,
                        Descrizione = VideoGioco.Descrizione,
                        Nome = VideoGioco.Nome,

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
                    CasaProduttriceId = ObjSent.CasaProduttriceId,
                    DataRilascio = ObjSent.DataRilascio,
                    Descrizione = ObjSent.Descrizione,
                    Nome = ObjSent.Nome
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
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x => x.AllegatiVideoGiochi).
                    FirstOrDefault(x => x.Id == ObjSent.VideoGameId)
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                foreach (IFormFile el in ObjSent.FileCaricato)
                {
                    using BinaryReader reader = new(el.OpenReadStream());
                    VideoGioco.AllegatiVideoGiochi.Add(new()
                    {
                        Content = reader.ReadBytes((int)el.Length),
                        NomeFile = el.FileName,
                        VideoGiocoId = VideoGioco.Id,
                        TipoAllegatoId=ObjSent.TipoAllegatoId
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
                List<AllegatoVideoGioco> AllegatoVideoGames = [.. _context.AllegatiVideoGiochi.Where(a => a.VideoGiocoId == Id)];
                foreach (AllegatoVideoGioco allegato in AllegatoVideoGames)
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
            DTO.VideoGame.RequisitiPC RequisitiPCObj = null;
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Models.VideoGioco VideoGioco = _context.VideoGiochi.FirstOrDefault(x => x.Id == Id)
                    ?? throw new ArgumentException(Constants.VideoGameNotFound);
                Models.CaratteristichaTecnica? RequisitoVideoGame = VideoGioco.RequisitoTecnico;
                if (RequisitoVideoGame != null)
                {
                     RequisitiPCObj = new()
                    {
                        Id = RequisitoVideoGame!.Id,
                        CPU = RequisitoVideoGame.CPU,
                        GPU = RequisitoVideoGame.GPU,
                        Memoria = RequisitoVideoGame.Memoria,
                        AdditionalNotes = RequisitoVideoGame.AdditionalNotes,
                        SchedaArchiviazione = RequisitoVideoGame.SchedaArchiviazione
                    };
                }
                return Ok(JsonConvert.SerializeObject(RequisitiPCObj, new JsonSerializerSettings()
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
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x => x.Generi).FirstOrDefault(x => x.Id == Id) ?? throw new ArgumentException(Constants.VideoGameNotFound);

                List<Models.Genere> GenereData = [.. VideoGioco.Generi!];
                foreach (Models.Genere Gen in GenereData)
                {
                    DTO.VideoGame.ListaGeneriGioco GenereGioco = new()
                    {
                        NomeGenere = Gen.Nome!
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
        }
        [HttpGet]
        [HttpGet]
        [Route("GetGenereById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetGenereById(int Id)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Models.Genere Genere = _context.Generi.FirstOrDefault(x => x.Id == Id) ?? throw new ArgumentException(Constants.VideoGameNotFound);
                DTO.VideoGame.ListaGeneriGioco GenereGioco = new()
                {
                    NomeGenere = Genere.Nome!,
                    Id = Genere.Id
                };
                return Ok(JsonConvert.SerializeObject(GenereGioco, new JsonSerializerSettings()
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
        [Route("GetAllGeneri")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllGeneri()
        {
            List<DTO.VideoGame.ListaGeneriGioco> GeneriList = [];
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);

                List<Models.Genere> GenereData = [.. _context.Generi.Include(x => x.VideoGiochi)];
                foreach (Models.Genere Gen in GenereData)
                {
                    DTO.VideoGame.ListaGeneriGioco GenereGioco = new()
                    {
                        NomeGenere = Gen.Nome!,
                        Id = Gen.Id,
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

        [HttpPost]
        [Route("CreateEditGenere")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEditGenere(GenerePost ObjSent)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Genere GenereNew = new()
                {
                    Nome = ObjSent.Nome,
                    Id = ObjSent.Id,
                };
                if (ObjSent.Id == 0) _context.Generi.Add(GenereNew);
                else _context.Generi.Update(GenereNew);
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
        public IActionResult AssociareGenereGioco(int GenereId, int GiocoId)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                Genere Genere = _context.Generi.FirstOrDefault(x => x.Id == GenereId) ?? throw new ArgumentException(Constants.BadRequest);
                Models.VideoGioco VideoGioco = _context.VideoGiochi.Include(x => x.Generi).FirstOrDefault(x => x.Id == GiocoId) ?? throw new ArgumentException(Constants.VideoGameNotFound);
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

        [HttpGet]
        [Route("DeleteGenere")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteGenere(int Id)
        {
            try
            {
                Genere Genere = _context.Generi.FirstOrDefault(a => a.Id == Id) ?? throw new ArgumentException(Constants.BadRequest);
                _context.Generi.Remove(Genere);
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
