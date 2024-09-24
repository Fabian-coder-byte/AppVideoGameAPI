using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Recensione
{
    public class RecensioneVideogioco
    {
        public string Descrizione { get; set; }
        public double Voto { get; set; }
        public string NomeUtente { get; set; }
        public string ImmagineUtente { get; set; }
        public DateTime Data { get; set; }
    }
}
