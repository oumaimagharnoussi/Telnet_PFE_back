namespace Ticketback.Models
{
    public class UpdateGroupeRequest
    {
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
