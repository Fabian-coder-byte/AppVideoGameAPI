using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Ordine
{
    public class OrdineItem
    {
        public string NomeVideogioco { get; set; }
        public string FormatoGioco { get; set; }
        public string ConsoleGioco { get; set; }
        public short Quantita { get; set; }
    }
}
