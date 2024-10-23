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
    public class ColoreController : BaseController
    {
        public ColoreController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.Colore>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<DTO.Colore> ListaColori = [];
            try
            {
                List<Colore> Colori = [.. _context.Colori];

                foreach (Colore col in Colori)
                {
                    DTO.Colore Colore = new()
                    {
                        Id = col.Id,
                        CodiceColore = col.CodiceColore!
                    };
                    ListaColori.Add(Colore);
                }

                return Ok(JsonConvert.SerializeObject(ListaColori, new JsonSerializerSettings()
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
        [Route("CreateEdit")]
        [ProducesResponseType(typeof(DTO.Console), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEdit([FromBody] FormColoreVM ObjSent)
        {
            try
            {
                if (!TryValidateModel(ObjSent)) return BadRequest();
                Models.Colore coloreObj = new()
                {
                    CodiceColore = ObjSent.CodiceColore,
                    Id = ObjSent.Id
                };
                if (ObjSent.Id == 0) _context.Colori.Update(coloreObj);
                else _context.Colori.Add(coloreObj);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(coloreObj, new JsonSerializerSettings()
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
        [ProducesResponseType(typeof(List<DTO.Colore>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                Colore Colore = _context.Colori.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException(Constants.ColoreNotFound);
                _context.Colori.Remove(Colore);
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(Colore, new JsonSerializerSettings()
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
