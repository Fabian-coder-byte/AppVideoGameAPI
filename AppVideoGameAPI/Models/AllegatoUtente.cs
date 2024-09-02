using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class AllegatoUtente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomeFile { get; set; }
        [Required]
        public byte[]? Content { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public DataUser? DataUser { get; set; }
    }
}
