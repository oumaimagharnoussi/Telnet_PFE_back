using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Activite
    {
        [Key]
        public int id { get; set; }
        public string libelle { get; set; }
    }
}
