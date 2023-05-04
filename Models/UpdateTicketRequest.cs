using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace Ticketback.Models
{
    public class UpdateTicketRequest
    {
        public Priorite Priorite { get; set; }
        public Type Type { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public HalfDay halfDay { get; set; }
        public int groupId { get; set; }
        [ForeignKey("groupId")]
        public Groupe Groupe { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }

        public int id { get; set; }
        [ForeignKey("etatId")]
        public Etat Etat { get; set; }
        public float dayNumber { get; set; }
        /*  public int siteId { get; set; }
          [ForeignKey("siteId")]
          public SiteTelnet Site { get; set; }*/
        [MaxLength(255)]
        public string File { get; set; }
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        /* public int prisEnChargePar { get; set; }
         [ForeignKey("prisEnChargePar")]
         public User PrisEnChargePar { get; set; }*/
        public int telnetId { get; set; }
        [ForeignKey("Telnet_Id")]
        public Telnet Telnet { get; set; }
    }
}
