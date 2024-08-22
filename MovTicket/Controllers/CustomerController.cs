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
                c_adress = viewModel.c_adress,
                c_email = viewModel.c_email,
                c_phone = viewModel.c_phone,
                c_subscription = viewModel.c_subscription
            };
            await dbContext.Customers.AddAsync(customer);

            await dbContext.SaveChangesAsync();
            

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customer = await dbContext.Customers.ToListAsync();
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int c_id)
        {
            var customer = await dbContext.Customers.FindAsync(c_id);

            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer viewModel)
        {
            var customer = await dbContext.Customers.FindAsync(viewModel.c_id);

            if (customer is not null) 
            {
                customer.c_name = viewModel.c_name;
                customer.c_adress = viewModel.c_adress;
                customer.c_email = viewModel.c_email;
                customer.c_phone = viewModel.c_phone;
                customer.c_subscription = viewModel.c_subscription;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Customer");
        }
    }
}
