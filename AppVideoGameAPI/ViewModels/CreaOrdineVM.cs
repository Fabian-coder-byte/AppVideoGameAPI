namespace AppVideoGameAPI.ViewModels
{
    public class CreaOrdineVM
    {
        public DateTime Data { get; set; }
        public string? UtenteId { get; set; }
        public int OrdineId { get; set; }

        public List<ItemOrdineVM> Items { get; set; }

    }
}
