using Microsoft.OData.Edm;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketback.Models
{

    public class WorkFromHomeRequest
    {
        [Key]
        public int workHomeRequestId { get; set; }

        [ForeignKey("userId")]
        public int userId { get; set; } // foreign key

        public User User { get; set; } // navigation property
       
        public string userNumber { get; set; }

        [JsonProperty("Full_name")]
        public string userFullName { get; set; }
       // public Activities activityName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string motive { get; set; }
        public Status state { get; set; }
        public int dayNumber { get; set; }
        public HalfDay halfDay { get; set; }

        // Utiliser les propriétés calculées pour mapper les colonnes
        [NotMapped]
        public string UserNumber
        {
            get { return User.userNumber; }
            set { userNumber = value; }
        }

        [NotMapped]
        public string UserFullName
        {
            get { return User.firstName + " " + User.lastName; }
            set { userFullName = value; }
        }
    }


}
