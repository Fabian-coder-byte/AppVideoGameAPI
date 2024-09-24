using AppVideoGameAPI.Models;
namespace AppVideoGameAPI.ViewModels
{
    public class RequisitiPCVM
    {
        public int Id { get; set; }
        public string? OS { get; set; }
        public string? Processor { get; set; }
        public string? Memory { get; set; }
        public string? Graphics { get; set; }
        public string? DirectX { get; set; }
        public string? Storage { get; set; }
        public string? AdditionalNotes { get; set; }
        public int LivelloRichiestoId { get; set; }
        public int VideoGiocoId { get; set; }
    }
}
