﻿
namespace AppVideoGameAPI.DTO.Stocks
{
    public class DatiVideoGame
    {
        public int Id { get; set; }
        public string NomeVideoGioco { get; set; }
        public string FormatoVideoGioco { get; set; }
        public string NomeConsole { get; set; }
        public short QuantitaRimanenti { get; set; }
        public string CasaProduttrice { get; set; }
        public double Prezzo { get; set; }
        public string CodeImage { get; set; }
        public string DescrizioneGioco { get; set; }
        public DateOnly? DataRilascio { get; set; }
    
    }
}
