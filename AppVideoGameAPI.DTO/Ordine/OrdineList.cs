using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Ordine
{
    public class OrdineList
    {
        public DateTime DataOrdine { get; set; }
        public string NomeCgnome { get; set; }
        public string Email { get; set; }
        public List<Ordine.OrdineItem> Items { get; set; }

    }
}
