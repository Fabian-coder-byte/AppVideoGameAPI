using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class Recensione
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public short Voto { get; set; }
        public string? Descrizione { get; set; }
        [Required]
        public int VideoGiocoId { get; set; }
        [ForeignKey(nameof(VideoGiocoId))]
        [ValidateNever]
        public VideoGioco? VideoGioco { get; set; }
        [Required]
        [StringLength(450)]
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public DataUser? Utente { get; set; }
        public DateTime Data { get; set; }
    }
}
