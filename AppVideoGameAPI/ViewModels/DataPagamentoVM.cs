using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.ViewModels
{
    public class DataPagamentoVM
    {
        [Required]
        public string? UserId { get; set; }
        public int? MetodoPagementoId { get; set; }
        public int StockId { get; set; }
    }
}
