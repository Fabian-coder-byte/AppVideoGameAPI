
namespace AppVideoGameAPI.DTO.VideoGame
{
    public class VideoGame
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        public int CasaProduttriceId { get; set; }
        public int CaratteristicaTecnicaId { get; set; }
    }
}
