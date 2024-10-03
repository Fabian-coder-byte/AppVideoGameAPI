using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class ItemOrdine
    {
        public int Id { get; set; }
        [Required]
        public int StockId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(StockId))]
        public StockVideoGioco? Stock { get; set; }
        public short Quantita { get; set; }
        [Required]
        public int OrdineId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(OrdineId))]
        public Ordine? Ordine { get; set; }
    }
}
