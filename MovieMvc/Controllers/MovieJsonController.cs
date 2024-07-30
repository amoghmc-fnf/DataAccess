using Microsoft.AspNetCore.Mvc;
using MovieMvc.Models;

namespace MovieMvc.Controllers
{
    public class MovieJsonController : Controller
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieJsonController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public JsonResult AllMovies() => Json(_movieDbContext.Movies.ToList());

        public JsonResult Find(string Title)
        {
            var movies = _movieDbContext.Movies.Where((m) => m.Title.Contains(Title)).ToList();
            return Json(movies);
        }

        public JsonResult GetMovie(int Id)
        {
            var movie = _movieDbContext.Movies.Where((m) => m.Id == Id).FirstOrDefault();
            if (movie == null)
                throw new NullReferenceException("Movie not found!");
            return Json(movie);

        }

        [HttpPost]
        public string AddMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return "Movie saved to database!";
        }

        [HttpPut]
        public string UpdateMovie(Movie movie)
        {
            var found = _movieDbContext.Movies.Where(m => m.Id == movie.Id).FirstOrDefault();
            if (found == null)
                throw new NullReferenceException("Movie not found to update!");
            found.Title = movie.Title;
            found.Director = movie.Director;
            found.Cast = movie.Cast;
            found.Description = movie.Description;
            found.Rating = movie.Rating;

            _movieDbContext.SaveChanges();
            return "Movie updated in the database!";
        }

        [HttpPost]
        public string DeleteMovie(int id)
        {
            var found = _movieDbContext.Movies.Where(m => m.Id == id).FirstOrDefault();
            if (found == null)
                throw new NullReferenceException("Movie not found to update!");

            _movieDbContext.Remove(found);
            _movieDbContext.SaveChanges();
            return "Movie deleted in the database!";
        }
    }
}
