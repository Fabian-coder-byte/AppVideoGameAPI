using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(UserId))]
        public DataUser? DataUser { get; set; }
    }
}
