using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class CaratteristichaTecnica
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)][Required]
        public string? CPU { get; set; }
        [StringLength(255)]
        [Required]
        public string? GPU { get; set; }
        [StringLength(255)]
        [Required]
        public string? Memoria { get; set; }
        [StringLength(255)]
        [Required]
        public string? SchedaArchiviazione { get; set; }
        [StringLength(255)]
        public string? AdditionalNotes { get; set; }
    }
}
