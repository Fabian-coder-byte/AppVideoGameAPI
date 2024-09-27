using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.VideoGame
{
    public class ListaGeneriGioco
    {
        public int Id { get; set; }
        public string NomeGenere { get; set; }
        public List<string>? VideoGiochi { get; set; }
    }
}
