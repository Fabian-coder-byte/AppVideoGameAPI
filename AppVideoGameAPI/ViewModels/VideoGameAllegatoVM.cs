namespace AppVideoGameAPI.ViewModels
{
    public class VideoGameAllegatoVM
    {
        public int VideoGameId { get; set; }
        public IFormFile[]? FileCaricato { get; set; }
        public int TipoAllegatoId { get; set; }
    }
}
