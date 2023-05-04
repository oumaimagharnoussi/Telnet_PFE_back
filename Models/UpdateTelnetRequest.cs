namespace Ticketback.Models
{
    public class UpdateTelnetRequest
    {
        public string libelle { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
