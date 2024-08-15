using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class RequisitiPC
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? RAM { get; set; }
        [Required]
        [StringLength(255)]
        public string? OS { get; set; }
        [Required]
        [StringLength(255)]
        public string? Processore { get; set; }
        [Required]
        [StringLength(255)]
        public string? SchedaGrafica { get; set; }
        [Required]
        [StringLength(255)]
        public string? Audio { get; set; }
        [Required]
        public int LivelloRichiestoId { get; set; }
        [ForeignKey(nameof(LivelloRichiestoId))]
        [ValidateNever]
        public LivelloRichiestoPC? LivelloRichiesto { get; set; }
        [Required]
        public int VideoGiocoId { get; set; }
        [ForeignKey(nameof(VideoGiocoId))]
        [ValidateNever]
        public VideoGioco? VideoGioco { get; set; }
    }
}
