using AppVideoGameAPI.ViewModels.VideoGiochi;

namespace AppVideoGameAPI.ViewModels
{
    public class VideoGameCreateVM
    {
        public DataVideoGameVM? DataVideoGame { get; set; }
        public FotoVideoVM? FotoVideo { get; set; }
        public GeneriVM? GeneriGame { get; set; }
        public RequisitoGiocoVM? RequisitoVM { get; set; }
    }
}
