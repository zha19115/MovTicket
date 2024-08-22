using System.ComponentModel.DataAnnotations;

namespace MovTicket.Models.Entities
{
    public class Customer
    {
        [Key]
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_Adress { get; set; }
        public string c_Email { get; set; }
        public string c_Phone { get; set; }
        public bool c_subscription { get; set; }


    }
}
