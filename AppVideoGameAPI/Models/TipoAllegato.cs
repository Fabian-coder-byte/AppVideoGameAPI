using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class TipoAllegato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
    }
}
