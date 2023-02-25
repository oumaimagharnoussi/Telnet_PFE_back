using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Etat
    {
        [Key]
        public int id { get; set; } 
        public string libelle { get; set; }
    }
}
