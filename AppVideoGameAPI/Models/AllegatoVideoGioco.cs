using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AppVideoGameAPI.Models
{
    public class AllegatoVideoGioco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomeFile { get; set; } 
        [Required]
        public byte[]? Content { get; set; }
        public int VideoGiocoId { get; set; }
        [Required]
        [ForeignKey(nameof(VideoGiocoId))]
        public VideoGioco? VideoGioco { get; set; }
        public int TipoAllegatoId { get; set; }
        [ForeignKey(nameof(TipoAllegatoId))]
        [Required]
        public TipoAllegato? TIpoAllegato { get; set; }
    }
}
