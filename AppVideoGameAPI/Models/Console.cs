using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class Console
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }
        [ValidateNever]
        public ICollection<VideoGioco>? VideoGiochi { get; set; }
    }
}
