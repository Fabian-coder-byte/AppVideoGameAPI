using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVideoGameAPI.DTO.VideoGame
{
    public class AllegatoVideoGame
    {
        public int Id { get; set; }

        public string NomeFile { get; set; } = string.Empty;
        public byte[]? Content { get; set; }

        public int? Piscina_id { get; set; }

    }
}
