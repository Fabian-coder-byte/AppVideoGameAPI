using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class Colore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CodiceColore { get; set; }
    }
}
