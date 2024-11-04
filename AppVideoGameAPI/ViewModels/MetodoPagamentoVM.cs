namespace AppVideoGameAPI.ViewModels
{
    public class MetodoPagamentoVM
    {
        public int Id { get; set; }
        public string NumeroCarta { get; set; }
        public int CVC { get; set; }
        public DateOnly DataScadenza { get; set; }
        public int TipoPagamentoId { get; set; }
        public double SaldoDisponibile { get; set; }
        public string? UserId { get; set; }
    }
}
