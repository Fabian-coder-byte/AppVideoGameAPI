using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class StockConsole
    {
        [Key]
        public int Id { get; set; }
        public int ModelloConsoleId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ModelloConsoleId))]
        public ModelloConsole? ModelloConsole { get; set; }
        public int ColoreId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(ColoreId))]
        public int CaratteristcaTecnicaId { get; set; }
        [ValidateNever]
        [Required]
        public CaratteristichaTecnica? CaratteristichaTecnica { get; set; }
        public Colore? Colore { get; set; }
        public double Prezzo { get; set; }
        public int Quantita { get; set; }
    }
}
