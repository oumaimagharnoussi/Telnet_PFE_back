using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Groupe
    {
        [Key]
        public int id { get; set; }
        public string libelle { get; set; }
    }
}
