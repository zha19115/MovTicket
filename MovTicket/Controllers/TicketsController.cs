using Microsoft.AspNetCore.Mvc;
using MovTicket.Data;
using MovTicket.Models;
using MovTicket.Models.Entities;

namespace MovTicket.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TicketsController(AppDbContext dbContext)
        {
            this._appDbContext = dbContext;
        }

        [HttpGet]

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTicketViewModel viewModel)
        {
            var ticket = new Ticket
            {
                m_id = viewModel.Movie
                //Customer. = viewModel.Email,
                
            };
            await _appDbContext.Tickets.AddAsync(ticket);

            return View();
        }
    }
}
