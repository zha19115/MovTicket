using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovTicket.Data;
using MovTicket.Models;
using MovTicket.Models.Entities;

namespace MovTicket.Controllers
{
    public class MovieController : Controller
    {

        private readonly AppDbContext _dbContext;

        public MovieController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
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
            var movie = await _dbContext.Movies.ToListAsync();
            return View(movie);
        }




        public async Task<IActionResult> List(string searchString)
        {
            if (_dbContext.Movies == null)
            {
                return Problem("Entity set 'MovTicket.Movie'  is null.");
            }

            var movies = from m in _dbContext.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.m_genre!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await movies.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int m_id)
        {
            var movie = await _dbContext.Movies.FindAsync(m_id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(Movie viewModel)
        {

            var movie = await _dbContext.Movies.FindAsync(viewModel.m_id);

            if (movie is not null)
            {
                movie.m_title = viewModel.m_title;
                movie.m_genre = viewModel.m_genre;
                movie.m_releaseDate = viewModel.m_releaseDate;
                movie.m_room = viewModel.m_room;
                movie.m_showTime = viewModel.m_showTime;

                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Movie");
        }
    }
}
