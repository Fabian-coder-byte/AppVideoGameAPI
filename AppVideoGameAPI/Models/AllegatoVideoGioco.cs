using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using AppVideoGameAPI.Models;

namespace PoolBookingApp.Models
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
    }
}
