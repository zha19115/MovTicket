using System.ComponentModel.DataAnnotations;

namespace MovTicket.Models.Entities
{
    public class Customer
    {
        [Key]
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_adress { get; set; }
        public string c_email { get; set; } = string.Empty;
        public string c_phone { get; set; } = string.Empty;
        public bool c_subscription { get; set; }

    }
}
