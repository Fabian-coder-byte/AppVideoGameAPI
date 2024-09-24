using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.Stocks
{
    public class VideoGameMenu
    {
        public int Id { get; set; }
        public string NomeVideoGioco { get; set; }
        public string NomeConsole { get; set; }
        public string FormatoVideoGioco { get; set; }
        public double Prezzo { get; set; }
        public int QuantitaRimanenti { get; set; }
        public string CodeImage { get; set; }

    }
}
