using System.ComponentModel.DataAnnotations;

namespace MovTicket.Models.Entities
{
    public class Customer
    {
        [Key]
        public int c_id { get; set; }
        public string c_name { get; set; }
        public string c_address { get; set; }
        public string c_email { get; set; } = string.Empty;
        public string c_phone { get; set; } = string.Empty;
        public bool c_subscription { get; set; }


        /*public Customer(int id, string name, string address, string email, string phone, bool subscription)
        {
            id = c_id;
            name = c_name;
            address = c_address;
            email = c_email;
            phone = c_phone;
            subscription = c_subscription;
        }*/
    }
}
