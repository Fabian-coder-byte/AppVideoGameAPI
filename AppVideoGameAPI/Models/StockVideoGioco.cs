using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class StockVideoGioco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VideoGiocoId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(VideoGiocoId))]
        public VideoGioco? VideoGioco { get; set; }
        [Required]
        public int FormatoGiocoId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(FormatoGiocoId))]
        public FormatoGioco? Formato { get; set; }
        [Required]
        public int ConsoleId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ConsoleId))] 
        public Console? Console { get; set; }
        public short Quantita { get; set; }
        [Required]
        public double Prezzo { get; set; }
    }
}
