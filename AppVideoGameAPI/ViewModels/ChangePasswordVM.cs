using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.ViewModels
{
    public class ChangePasswordVM
    {
        public string? UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo 'PasswordCorrente' è obbligatorio")]
        [DataType(DataType.Password)]
        public string? PasswordCorrente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo 'NuovaPassword' è obbligatorio")]
        [MinLength(6, ErrorMessage = "Il campo 'Password' deve avere un minimo di 6 caratteri")]
        [DataType(DataType.Password)]
        public string? NuovaPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo 'ConfermaPassword' è obbligatorio")]
        [Compare("NuovaPassword", ErrorMessage = "Il campo 'Conferma Password' non corrisponde alla Password inserita")]
        [DataType(DataType.Password)]
        public string? ConfermaPassword { get; set; }
    }
}
