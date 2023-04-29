using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ticketback.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; } 
        public string userNumber { get; set; }
        public string firstName { get; set; } 
        public string lastName { get; set; }
        public string userName { get; set; } 
        public string userPassword { get; set; }
        public string email { get; set; } 
        public string picture { get; set; }
        public int qualification { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

        public string ResetPasswordToken { get; set; }
        public DateTime ResetPasswordExpiry { get; set; }

        public List<WorkFromHomeRequest> WorkFromHomeRequests { get; set; }
        public List<Ticket> Ticket { get; set; }
        public List<Commentaire> Commentaire { get; set; }

        public int activityId { get; set; }
        [ForeignKey("activityId")]
       
        public Activitie Activitie { get; set; }

        public int groupId { get; set; }
        [ForeignKey("groupId")]
        
        public  Groupe Groupe { get; set; }

       /* public int sId { get; set; }
        [ForeignKey("sId")]
        public SiteTelnet SiteTelnet { get; set; }*/
    }
}
