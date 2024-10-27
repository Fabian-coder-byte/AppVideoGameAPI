using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class TipoPagamento
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
    }
}
