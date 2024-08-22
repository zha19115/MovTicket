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


        /*public Customer(int id, string name, string adress, string email, string phone, bool subscription)
        {
            id = c_id;
            name = c_name;
            adress = c_adress;
            email = c_email;
            phone = c_phone;
            subscription = c_subscription;
        }*/
    }
}
