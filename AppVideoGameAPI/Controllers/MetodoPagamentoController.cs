using AppVideoGameAPI.Data;
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
                     [.. _context.MetodoPagamento.Include(x => x.TipoPagamento).Where(x => x.UserId == userId)];
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
                       Intestatario=metodo.Intestatario!
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
                    SaldoDisponibile=DataSent.SaldoDisponibile,
                    TipoPagamentoId=DataSent.TipoPagamentoId,
                    Intestatario=DataSent.Intestatario
                };
                _context.MetodoPagamento.Add(MetodoPagamento);
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
