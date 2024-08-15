using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class LivelloRichiestoPC
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }
    }
}
