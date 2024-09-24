using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.DTO.VideoGame
{
    public class RequisitiPC
    {
        public int Id { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public string? Graphics { get; set; }
        public string? DirectX { get; set; }
        public string? Storage { get; set; }
        public string? AdditionalNotes { get; set; }
        public string? LivelloRichiesto { get; set; }
    }
}
