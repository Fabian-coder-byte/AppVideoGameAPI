using Microsoft.AspNetCore.Identity;
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
    }
}
