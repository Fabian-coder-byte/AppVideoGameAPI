using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class ElementoProferito
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        [Required]
        public StockVideoGioco? StockVideoGioco { get; set; }
        public DateTime DataInserimento { get; set; }
        [Required]
        [StringLength(450)]
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public DataUser? DataUser { get; set; }
    }
}
