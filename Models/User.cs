using System.ComponentModel.DataAnnotations;

namespace Ticketback.Models
{
    public class User
    {
        [Key]
        public int id { get; set; } //Id
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

        //public List<Activite> Activites { get; set; }
       // public List<Site> Sites { get; set; }
       // public List<Groupe> Groupes { get; set; }
    }
}
