using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO
{
    public class TipoPagamento
    {
        public int Id { get; set; }
        public string NomeTipo { get; set; }
        public List<MetodoPagamento> MetodiPagamenti { get; set; }
    }
}
