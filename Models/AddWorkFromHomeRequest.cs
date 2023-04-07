using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketback.Models
{
    public class AddWorkFromHomeRequest
    {
        public int userId { get; set; } // foreign key
        [ForeignKey("userId")]
        public User User { get; set; } // navigation property
        [NotMapped]
        public string userNumber
        {
            get { return User.userNumber; }
        }

        [NotMapped]
        public string userFullName
        {
            get { return User.firstName + " " + User.lastName; }
        }
        //public Activities activityName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string motive { get; set; }
        public Status state { get; set; }
        public int dayNumber { get; set; }
        public HalfDay halfDay { get; set; }
    }
}
