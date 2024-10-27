using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class ItemCarrello
    {
        public int Id { get; set; }
        [Required]
        public int StockId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(StockId))]
        public StockVideoGioco? Stock { get; set; }
        public short Quantita { get; set; }
        public double Prezzo { get; set; }
        [Required]
        public int CarrelloId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(CarrelloId))]
        public CarrelloOrdine? CarrelloOrdine { get; set; }
    }
}
