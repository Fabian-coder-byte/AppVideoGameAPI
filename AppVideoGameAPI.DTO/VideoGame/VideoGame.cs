
namespace AppVideoGameAPI.DTO.VideoGame
{
    public class VideoGame
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        public int CasaProduttriceId { get; set; }
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string Memoria { get; set; }
        public string SchedaArchiviazione { get; set; }
        public string? DescrizioneTecnica { get; set; }
    }
}
