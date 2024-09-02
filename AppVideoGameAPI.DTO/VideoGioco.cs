namespace AppVideoGameAPI.DTO
{
    public class VideoGioco
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        public int CasaProduttriceId { get; set; }
    }
}
