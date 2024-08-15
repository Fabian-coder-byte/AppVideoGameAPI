using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class CasaProduttrice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }
    }
}
