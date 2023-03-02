namespace Ticketback.Models
{
    public class AddUserRequest
    {
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
        public int groupId { get; set; }
        public int activityId { get; set; }
    }
}
