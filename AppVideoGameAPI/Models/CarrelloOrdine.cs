using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class CarrelloOrdine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string? UtenteId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(UtenteId))]
        public DataUser? DataUser { get; set; }
        [ValidateNever]
        public ICollection<ItemCarrello>? ItemsCarrello { get; set; }
    }
}
