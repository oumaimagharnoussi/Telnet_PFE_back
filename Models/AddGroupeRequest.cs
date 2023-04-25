namespace Ticketback.Models
{
    public class AddGroupeRequest
    {
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
