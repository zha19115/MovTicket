namespace MovTicket.Models
{
    public class AddTicketViewModel
    {
        public Guid t_id { get; set; }

        public int Movie { get; set; }
        public string Email { get; set; }
        public bool Subscription { get; set; }
    }
}
