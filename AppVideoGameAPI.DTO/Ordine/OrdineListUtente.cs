using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Ordine
{
    public class OrdineListUtente
    {
        public DateTime? DataOrdine { get; set; }
        public List<Ordine.OrdineItem> Items { get; set; }
    }
}
