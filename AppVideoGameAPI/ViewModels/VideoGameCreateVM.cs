namespace AppVideoGameAPI.ViewModels
{
    public class VideoGameCreateVM
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        public int CasaProduttriceId { get; set; }
        public string? GPU { get; set; }
        public string? CPU { get; set; }
        public string? Memoria { get; set; }
        public string? SchedaArchiviazione { get; set; }
        public string? DescrizioneTecnica { get; set; }
        public IFormFile? FotoGioco { get; set; }
        public IFormFile[]? FotoSlider { get; set; }
        public IFormFile[]? Video { get; set; }
        public List<int>? Generi { get; set; }
    }
}
