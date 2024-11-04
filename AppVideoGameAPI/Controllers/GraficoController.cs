using AppVideoGameAPI.Data;
using AppVideoGameAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppVideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficoController : BaseController
    {
        public GraficoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]
        [Route("GetAcquistiMensili")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAcquistiMensili(string userId)
        {
            List<DTO.AcquistoMensile> results = [];

            try
            {
                List<Models.FormatoGioco> formatiVideoGiochi = _context.Formati.Include(x => x.StocksVideoGiochi).ToList();
                var ordini = _context.Ordini
                    .Include(x => x.ItemOrdini)!.ThenInclude(x => x.Stock)
                    .Where(x => x.UtenteId == userId)
                    .ToList();

                foreach (Models.FormatoGioco formato in formatiVideoGiochi)
                {
                    List<int> numeroAcquisti = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
                    string nomeFormato = formato.Nome;

                    foreach (Models.Ordine ordine in ordini)
                    {
                        int mese = ordine.Data.Month - 1;
                        int numeroGiochi = ordine.ItemOrdini!.Where(x => x.Stock!.FormatoGiocoId == formato.Id).Sum(x => x.Quantita);
                        numeroAcquisti[mese] += numeroGiochi;
                    }
                    DTO.AcquistoMensile acquistoMensile = new()
                    {
                        NomeFormato = nomeFormato,
                        NumeriAcquisti = numeroAcquisti,
                    };

                    results.Add(acquistoMensile);
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSpeseMensili")]
        [ProducesResponseType(typeof(List<DTO.Ordine.OrdineList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetSpeseMensili(string userId)
        {
            List<double> results = [0,0,0,0,0,0,0,0,0,0,0,0];
            try
            {
                List<Ordine> Ordini = [.. _context.Ordini
                    .Include(x => x.ItemOrdini)
                    .Where(x => x.UtenteId == userId)];

                foreach (Models.Ordine o in Ordini) 
                {
                    int mese = o.Data.Month - 1;
                    double spesa = o.ItemOrdini!.Sum(x => x.Prezzo * x.Quantita);
                    results[mese] = spesa;
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
