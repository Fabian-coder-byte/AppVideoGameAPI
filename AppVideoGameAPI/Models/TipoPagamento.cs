using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class TipoPagamento
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [ValidateNever]
        public ICollection<MetodoPagamento>? MetodiPagamenti { get; set; }
    }
}
