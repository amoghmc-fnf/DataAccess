using Microsoft.AspNetCore.Mvc;
using MovieMvc.Models;

namespace MovieMvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public IActionResult AllMovies()
        {
            var movies = _movieDbContext.Movies.ToList();
            movies.Sort();
            return View(movies);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var record = _movieDbContext.Movies.FirstOrDefault(m => m.Id == id);

            if (record == null)
                return NotFound();
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Movie postedData)
        {
            var id = postedData.Id;
            var record = _movieDbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (record == null)
                return NotFound();

            record.Title = postedData.Title;
            record.Description = postedData.Description;
            record.Director = postedData.Director;
            record.Cast = postedData.Cast;
            record.Rating = postedData.Rating;
            _movieDbContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        public IActionResult Create() => View(new Movie());

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (movie != null)
            {
                _movieDbContext.Movies.Add(movie);
                _movieDbContext.SaveChanges();
                return RedirectToAction("AllMovies");
            }
            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var record = _movieDbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (record == null)
                return NotFound();
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(Movie postedData)
        {
            var id = postedData.Id;
            var record = _movieDbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (record == null)
                return NotFound();

            _movieDbContext.Remove(record);
            _movieDbContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }
    }
}
