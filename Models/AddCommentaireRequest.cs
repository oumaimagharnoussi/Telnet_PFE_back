using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ticketback.Models

{
    public class AddCommentaireRequest
    {
        public string libelle { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }
    }
}
