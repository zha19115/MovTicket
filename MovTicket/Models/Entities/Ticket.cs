using MovTicket.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MovTicket.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int t_id { get; set; }
        public string t_seat { get; set; }

        //Enum
        //public TicketCategory Category { get; set; }


        //Foreign Keys
        public int m_id { get; set; }
        public int c_id { get; set; }

        public Movie Movie { get; set; }
        public Customer Customer { get; set; }

    }
}
