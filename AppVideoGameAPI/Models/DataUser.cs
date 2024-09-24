using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class DataUser:IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cognome { get; set; }
        [Required]
        public string? IndirizzoUtente { get; set; }
        public DateTime? UltimoAccesso { get; set; }
        [ValidateNever]
        public ICollection<AllegatoUtente>? AllegatiUtenti { get; set; }
    }
}
