using AppVideoGameAPI.Models;
namespace AppVideoGameAPI.ViewModels
{
    public class RequisitiPCVM
    {
        public int Id { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Memoria { get; set; }
        public string SchedaArchiviazione { get; set; }
        public string Note { get; set; }
    }
}
