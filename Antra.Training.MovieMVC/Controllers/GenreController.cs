using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAll();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);

            await _genreRepository.Insert(genre);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreRepository.GetById(id);
            if (genre == null) return NotFound();

            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);

            await _genreRepository.Update(genre);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepository.GetById(id);
            if (genre == null) return NotFound();

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _genreRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
