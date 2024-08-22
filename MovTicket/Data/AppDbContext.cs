using Microsoft.EntityFrameworkCore;
using MovTicket.Models.Entities;

namespace MovTicket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {      
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }



    }
}
