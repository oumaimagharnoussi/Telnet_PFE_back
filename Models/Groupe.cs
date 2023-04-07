using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Groupe
    {
        [Key]
        public int groupId { get; set; }
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
