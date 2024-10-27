using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class IndirizzoResidenza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomeIndirizzo { get; set; }
        [Required]
        [StringLength(150)]
        public string? NomeCitta { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public DataUser? DataUser { get; set; }
    }
}
