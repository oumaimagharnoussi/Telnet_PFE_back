using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ticketback.Models
{
    public class Commentaire
    {
        [Key]
        public int commentaireId { get; set; }
        public string libelle { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }

        public int ticketId { get; set; }
        [ForeignKey("ticketId")]
        public Ticket Ticket { get; set; }

    }
}
