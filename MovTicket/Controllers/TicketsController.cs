using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models;
using MovTicket.Models.Entities;
using MovTicket.Models.Enum;
using System.Net.Sockets;

namespace MovTicket.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext dbContext;
        public TicketsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Create()
        { 
            ViewBag.EnumTicket = Enum.GetValues(typeof(EnumTicket)).Cast<EnumTicket>();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // Speichern des Tickets in der Datenbank (logik hier)
                return RedirectToAction("Index");
            }

            // Falls ModelState nicht gültig ist, Ticketarten erneut anzeigen
            ViewBag.TicketTypes = Enum.GetValues(typeof(EnumTicket)).Cast<EnumTicket>();
            return View(ticket);
        }

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

