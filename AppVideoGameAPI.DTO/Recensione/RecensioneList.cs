
namespace AppVideoGameAPI.DTO.Recensione
{
    public class RecensioneList
    {
        public short Voto { get; set; }
        public string? Descrizione { get; set; }
        public string NomeVideoGioco { get; set; }
        public string NomeCognomeUtente { get; set; }
        public string EmailUtente { get; set; }
        public DateTime Data { get; set; }
    }
}
