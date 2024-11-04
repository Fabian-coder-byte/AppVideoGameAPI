using AppVideoGameAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace AppVideoGameAPI.ViewModels
{
    public class IndirzzoUtenteVM
    {
        public int Id { get; set; }
        public string? NomeIndirizzo { get; set; }
        public string? NomeCitta { get; set; }
        public string? UserId { get; set; }
    }
}
