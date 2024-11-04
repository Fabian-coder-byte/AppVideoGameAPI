
namespace AppVideoGameAPI.DTO
{
    public class MetodoPagamento
    {
        public int Id { get; set; }
        public string? NumeroCarta { get; set; }
        public int CVC { get; set; }
        public DateOnly DataScadenza { get; set; }
        public double SaldoDisponibile { get; set; }
        public string TipoPagamento { get; set; }
    }
}
