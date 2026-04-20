using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Antra.Training.MovieMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetHighestGrossingMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
