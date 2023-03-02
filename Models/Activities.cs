using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class Activities
    {
        [Key]
        public int activityId { get; set; }
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
