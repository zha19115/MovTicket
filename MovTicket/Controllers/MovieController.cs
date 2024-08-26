using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models;

namespace MovTicket.Controllers
{
    public class MovieController : Controller
    {

        private readonly AppDbContext dbContext;

        public MovieController(AppDbContext dbContext) 
        {
            dbContext = dbContext;
        }

        //[HttpGet]
        //public async Task<IActionResult> SelectMovie()
        //{
        //    // Daten aus der Datenbank abrufen
        //    var movies = await _dbContext.Movies.ToListAsync();

        //    // Die Liste der Filme an die View übergeben
        //    return View(movies);
        //}

        //[HttpPost]
        //public async Task<IActionResult> SubmitMovieSelection(int selectedMovieId)
        //{
        //    // Logik für die Verarbeitung der Auswahl
        //    var selectedMovie = await _dbContext.Movies.FindAsync(selectedMovieId);
        //    if (selectedMovie == null)
        //    {
        //        return NotFound();
        //    }
        //    return RedirectToAction("MovieDetails", new { id = selectedMovieId });
        //}

        [HttpGet]
        public async Task<IActionResult> List()
        { 
            var movie = await dbContext.Movies.ToListAsync();
            return View(movie);
        }

        public async Task<IActionResult> Detail(int m_id)
        {
            var movie = await dbContext.Movies.FindAsync(m_id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
