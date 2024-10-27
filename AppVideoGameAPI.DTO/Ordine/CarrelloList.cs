using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Ordine
{
    public class CarrelloList
    {
        public int CarrelloId { get; set; }
        public List<OrdineItem> Items { get; set; }
    }
}
