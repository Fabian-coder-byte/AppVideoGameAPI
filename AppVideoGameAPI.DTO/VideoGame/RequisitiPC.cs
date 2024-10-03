using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.DTO.VideoGame
{
    public class RequisitiPC
    {
        public int Id { get; set; }
        public string? CPU { get; set; }
        public string? GPU { get; set; }
        public string? Memoria { get; set; }
        public string? SchedaArchiviazione { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
