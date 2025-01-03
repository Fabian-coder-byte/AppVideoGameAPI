namespace AppVideoGameAPI.ViewModels.VideoGiochi
{
    public class DataVideoGameVM
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        public int CasaProduttriceId { get; set; }
    }
}
