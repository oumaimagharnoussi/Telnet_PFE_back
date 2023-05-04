namespace Ticketback.Models
{
    public class AddTelnetRequest
    {
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
