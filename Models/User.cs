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
        public int userId { get; set; } //Id
        public string userNumber { get; set; }
        public string firstName { get; set; } //FirstName
        public string lastName { get; set; } //LastName
        public string userName { get; set; } //Username
        public string userPassword { get; set; } //Password
        public string email { get; set; } //Email
        public string picture { get; set; }
        public int qualification { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

        public string ResetPasswordToken { get; set; }
        public DateTime ResetPasswordExpiry { get; set; }
      
       // public Groups groupId { get; set; }

        public List<WorkFromHomeRequest> WorkFromHomeRequests { get; set; }

       
         public int activityId { get; set; }
         public Activitie Activitie { get; set; }
        [ForeignKey("Groupe")]
        public int groupId { get; set; }
        public Groupe Groupe { get; set; }
    }
}
