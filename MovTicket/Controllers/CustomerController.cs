using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models;
using MovTicket.Models.Entities;

namespace MovTicket.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext dbContext;

        public CustomerController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel viewModel )
        {
            var customer = new Customer
            {
                c_name = viewModel.c_name,
                c_address = viewModel.c_address,
                c_email = viewModel.c_email,
                c_phone = viewModel.c_phone,
                c_subscription = viewModel.c_subscription
            };
            await dbContext.Customers.AddAsync(customer);

            await dbContext.SaveChangesAsync();


            return View();
        }

        

    }
}
