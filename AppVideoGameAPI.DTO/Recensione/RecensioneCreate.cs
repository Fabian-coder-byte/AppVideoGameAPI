﻿
namespace AppVideoGameAPI.DTO.Recensione
{
    public class RecensioneCreate
    {
        public short Voto { get; set; }
        public string? Descrizione { get; set; }
        public int VideoGiocoId { get; set; }
        public string? UserId { get; set; }
        public DateTime Data { get; set; }
    }
}