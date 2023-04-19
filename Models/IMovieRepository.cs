using System.Collections.Generic;
using System.Linq;

namespace PracticeFinalExam.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }
        IQueryable<Category> Categories { get; }
        IEnumerable<Movie> GetMovies();
        IEnumerable<Category> GetCategories();
        Movie GetMovieByID(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void RemoveMovie(int id);
    }
}
