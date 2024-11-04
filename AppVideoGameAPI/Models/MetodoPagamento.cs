using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class MetodoPagamento
    {
        public int Id { get; set; }
        public string? NumeroCarta { get; set; }
        [Required]
        [Range(3,3)]
        public int CVC { get; set; }
        [Required]  
        public DateOnly DataScadenza { get; set; }
        [Required]
        public string? Intestatario { get; set; }
        public int TipoPagamentoId { get; set; }
        [ForeignKey(nameof(TipoPagamentoId))]
        [Required]
        public TipoPagamento? TipoPagamento { get; set; }
        public double SaldoDisponibile { get; set; }
        [Required]
        public string? UserId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(UserId))]
        public DataUser? DataUser { get; set; }
    }
}
