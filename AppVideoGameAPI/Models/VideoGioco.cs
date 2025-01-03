﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVideoGameAPI.Models
{
    public class VideoGioco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public DateOnly? DataRilascio { get; set; }
        [Required]
        public int CasaProduttriceId { get; set; }
        [ForeignKey(nameof(CasaProduttriceId))]
        public int? CaratteristicaTecnicaId { get; set; }
        [ForeignKey(nameof(CaratteristicaTecnicaId))]
        public CaratteristichaTecnica? RequisitoTecnico { get; set; }
        [ValidateNever]
        public CasaProduttrice? CasaProduttrice { get; set; }
        [ValidateNever]
        public ICollection<Genere>? Generi { get; set; }
        [ValidateNever]
        public ICollection<ModelloConsole>? Consoles { get; set; }
        [ValidateNever]
        public ICollection<Funzionalita>? Funzionalitas { get; set; }
        [ValidateNever]
        public ICollection<AllegatoVideoGioco>? AllegatiVideoGiochi { get; set; }

    }
}
