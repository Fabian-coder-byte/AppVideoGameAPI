using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class FormatoGioco
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
    }
}
