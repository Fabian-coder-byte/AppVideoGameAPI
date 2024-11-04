using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AppVideoGameAPI.Utilities;
using AppVideoGameAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagamentoController : BaseController
    {
        public MetodoPagamentoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll(string userId)
        {
            try
            {
                List<Models.MetodoPagamento> MetodiPagamento =
                     [.. _context.MetodoPagamento.Include(x => x.TipoPagamento).Where(x => x.UserId == userId && !x.Eliminato)];
                List<DTO.MetodoPagamento> Result = [];
                foreach (Models.MetodoPagamento metodo in MetodiPagamento)
                {
                    DTO.MetodoPagamento Metodo = new()
                    {
                        CVC = metodo.CVC,
                        DataScadenza = metodo.DataScadenza,
                        Id = metodo.Id,
                        NumeroCarta = metodo.NumeroCarta,
                        SaldoDisponibile = metodo.SaldoDisponibile,
                        TipoPagamento = metodo.TipoPagamento!.Nome!,
                        Intestatario = metodo.Intestatario!
                    };
                    Result.Add(Metodo);
                }
                return Ok(JsonConvert.SerializeObject(Result, new JsonSerializerSettings()
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
        [Route("GetAllTipiPagamento")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllTipiPagamento()
        {
            try
            {
                List<Models.TipoPagamento> TipiPagamento =
                     [.. _context.TipoPagemento];
                List<DTO.TipoPagamento> Result = [];
                foreach (Models.TipoPagamento tip in TipiPagamento)
                {
                    DTO.TipoPagamento TIpoPag = new()
                    {
                       Id = tip.Id,
                       NomeTipo=tip.Nome!
                    };
                    Result.Add(TIpoPag);
                }
                return Ok(JsonConvert.SerializeObject(Result, new JsonSerializerSettings()
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
        [Route("Remove")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Remove(int Id)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                MetodoPagamento MetodoPag = _context.MetodoPagamento.FirstOrDefault(o => o.Id == Id && !o.Eliminato) 
                    ?? throw new ArgumentException(Constants.MetodoPagamentoNotFound);
                MetodoPag.Eliminato = true;
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(MetodoPag, new JsonSerializerSettings()
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
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int Id)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(Constants.BadRequest);
                MetodoPagamento MetodoPag = _context.MetodoPagamento.Include(x=>x.TipoPagamento).FirstOrDefault(o => o.Id == Id && !o.Eliminato)
                    ?? throw new ArgumentException(Constants.MetodoPagamentoNotFound);
                DTO.MetodoPagamento MetodoPagamentoObj = new()
                {
                    CVC= MetodoPag.CVC,
                    Id= Id,
                    DataScadenza= MetodoPag.DataScadenza,
                    Intestatario= MetodoPag.Intestatario!,
                    NumeroCarta= MetodoPag.NumeroCarta,
                    SaldoDisponibile= MetodoPag.SaldoDisponibile,
                    TipoPagamento=MetodoPag.TipoPagamento.Nome,
                    TipoPagamentoId=MetodoPag.TipoPagamentoId
                };
                return Ok(JsonConvert.SerializeObject(MetodoPagamentoObj, new JsonSerializerSettings()
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
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEdit([FromBody] MetodoPagamentoVM DataSent)
        {
            try
            {
                if (!TryValidateModel(DataSent))
                {
                    throw new ArgumentException(Constants.BadRequest);
                }

                Models.MetodoPagamento MetodoPagamento = new()
                {
                    DataScadenza = DataSent.DataScadenza,
                    CVC = DataSent.CVC,
                    NumeroCarta = DataSent.NumeroCarta,
                    UserId = DataSent.UserId,
                    Id = DataSent.Id,
                    SaldoDisponibile = DataSent.SaldoDisponibile,
                    TipoPagamentoId = DataSent.TipoPagamentoId,
                    Intestatario = DataSent.Intestatario
                };
                if(DataSent.Id == 0)
                {
                    _context.MetodoPagamento.Add(MetodoPagamento);
                }
                else
                {
                    _context.MetodoPagamento.Update(MetodoPagamento);
                }
                _context.SaveChanges();
                return Ok(JsonConvert.SerializeObject(MetodoPagamento, new JsonSerializerSettings()
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
