using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.Models
{
    public class AllegatoVideoGiocoStock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? NomeFile { get; set; }
        [Required]
        public byte[]? Content { get; set; }
        public int VideoGiocoStockId { get; set; }
        [Required]
        [ForeignKey(nameof(VideoGiocoStockId))]
        public StockVideoGioco? StockVideoGioco { get; set; }
        public int TipoAllegatoId { get; set; }
        [ForeignKey(nameof(TipoAllegatoId))]
        [Required]
        public TipoAllegato? TIpoAllegato { get; set; }
    }
}
