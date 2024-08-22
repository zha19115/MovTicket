using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovTicket.Data;

namespace MovTicket.Controllers
{
    public class MovieController : Controller
    {

        private readonly AppDbContext _dbContext;

        public MovieController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> SelectMovie()
        {
            // Daten aus der Datenbank abrufen
            var movies = await _dbContext.Movies.ToListAsync();

            // Die Liste der Filme an die View übergeben
            return View(movies);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMovieSelection(int selectedMovieId)
        {
            // Logik für die Verarbeitung der Auswahl
            var selectedMovie = await _dbContext.Movies.FindAsync(selectedMovieId);
            if (selectedMovie == null)
            {
                return NotFound();
            }
            return RedirectToAction("MovieDetails", new { id = selectedMovieId });
        }
    }
}
