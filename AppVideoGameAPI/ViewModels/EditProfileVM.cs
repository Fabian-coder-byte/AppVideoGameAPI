using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.ViewModels
{
    public class EditProfileVM
    {
        [Required]
        public string? UserId { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Telefono { get; set; }
    }
}
