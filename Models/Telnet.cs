using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Telnet
    {
        [Key]
        public int telnetId { get; set; }
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
