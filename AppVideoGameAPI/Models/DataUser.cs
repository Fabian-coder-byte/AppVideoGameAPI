using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class DataUser:IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cognome { get; set; }
        public DateTime? UltimoAccesso { get; set; }
        public bool AccettaUsoDati { get; set; }
        public double SaldoDisponibile { get; set; }
        [ValidateNever]
        public ICollection<AllegatoUtente>? AllegatiUtenti { get; set; }
        [ValidateNever]
        public ICollection<IndirizzoResidenza>? IndirizziResidenza { get; set; }
        [ValidateNever]
        public ICollection<ElementoProferito>? ElementiProferiti { get; set; }
        [ValidateNever]
        public ICollection<Ordine>? Ordini { get; set; }
        [ValidateNever]
        public ICollection<MetodoPagamento>? MetodiPagamento { get; set; }
    }
}
