using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PracticeFinalExam.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieContext context;
        public EFMovieRepository(MovieContext temp)
        {
            context = temp;
        }
        
        public IQueryable<Movie> Movie => context.Movies;
        public IQueryable<Category> Categories => context.Categories;

        IQueryable<Movie> IMovieRepository.Movies { get; }
        IQueryable<Category> IMovieRepository.Categories { get; }

        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies.Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Movie GetMovieByID(int id)
        {
            return context.Movies.Find(id);
        }
        public void AddMovie(Movie movie)
        {

            context.Add(movie);

            context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {

            context.Update(movie);

            context.SaveChanges();
        }

        public void RemoveMovie(int id )
        {
            Movie movie = context.Movies.Find(id);
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
