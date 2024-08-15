using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class Funzionalita
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        [Required]
        public int VideoGiocoId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(VideoGiocoId))]
        public VideoGioco? VideoGioco { get; set; }
    }
}
