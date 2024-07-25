using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMvc.Models
{
    [Table("Movie")]
    public class Movie : IComparable<Movie>
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Cast {  get; set; }
        public int Rating { get; set; }

        public int CompareTo(Movie? other)
        {
            var ratingComparison = this.Rating.CompareTo(other.Rating);
            if (ratingComparison == 0)
                return this.Title.CompareTo(other.Title);
            return -ratingComparison;
        }
    }

    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieDbContext(DbContextOptions options) : base(options) { }
    }
}
