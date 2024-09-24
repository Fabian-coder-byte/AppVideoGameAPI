
namespace AppVideoGameAPI.DTO.VideoGame
{
    public class AllegatiVideogiochi
    {
        public int Id { get; set; }
        public string? NomeFile { get; set; }
        public byte[]? Content { get; set; }
        public int VideoGiocoId { get; set; }
    }
}
