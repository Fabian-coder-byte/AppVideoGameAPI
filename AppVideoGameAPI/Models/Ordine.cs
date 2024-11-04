using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class Ordine
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        [Required]
        [StringLength(450)]
        public string? UtenteId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(UtenteId))]
        public DataUser DataUser { get; set; }
        public int MetodoPagamentoId { get; set; }
        public MetodoPagamento? MetodoPagamento { get; set; }
        [ValidateNever]
        public ICollection<ItemOrdine>? ItemOrdini { get; set; }
    }
}
