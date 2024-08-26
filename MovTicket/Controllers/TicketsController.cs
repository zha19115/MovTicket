using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        //[HttpPost]
        //public async Task<IActionResult> Create(Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ticket.t_id = Guid.NewGuid();
        //        ticket.t_seat = DateTime.Now;
        //        dbcon.Add(ticket);
        //        await dbContext.SaveChangesAsync();
        //        return RedirectToAction("List");
        //    }

        //    return View(ticket);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbContext.Update(ticket);
        //        await dbContext.SaveChangesAsync();
        //        return RedirectToAction("List");
        //    }

        //    return View(ticket);
        //}
    }
}

