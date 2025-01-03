namespace AppVideoGameAPI.ViewModels.VideoGiochi
{
    public class FotoVideoVM
    {
        public int Id { get; set; }
        public IFormFile? FotoGioco { get; set; }
        public IFormFile[]? FotoSlider { get; set; }
        public IFormFile[]? Video { get; set; }
    }
}
