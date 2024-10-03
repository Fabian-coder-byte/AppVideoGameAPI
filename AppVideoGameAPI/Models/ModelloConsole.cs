using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class ModelloConsole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        public int ConsoleId { get; set; }
        [ForeignKey(nameof(ConsoleId))]
        [Required]
        public Console? Console { get; set; }
        [ValidateNever]
        public ICollection<VideoGioco>? VideoGiochi { get; set; }
    }
}
