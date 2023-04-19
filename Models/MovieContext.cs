using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeFinalExam.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                 new Category { CategoryID=1, CategoryName= "Action/Adventure" },
                 new Category { CategoryID = 2, CategoryName = "Romance" },
                 new Category { CategoryID = 3, CategoryName = "Rom/Com" },
                 new Category { CategoryID = 4, CategoryName = "Comedy" },
                 new Category { CategoryID = 5, CategoryName = "Drama" },
                 new Category { CategoryID = 6, CategoryName = "Family" },
                 new Category { CategoryID=7, CategoryName = "Horror/Suspense" },
                 new Category { CategoryID = 8, CategoryName = "Miscellaneous" },
                 new Category { CategoryID = 9, CategoryName = "Television" },
                 new Category { CategoryID = 10, CategoryName = "VHS" }
                );

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "The Dark Knight",
                    Year = 2013,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Josh",
                    Notes = "Great Movie"
                },
                new Movie
                {
                    MovieID = 2,
                    CategoryID = 3,
                    Title = "Crazy Stupid Love",
                    Year = 2013,
                    Director = "Some Guy",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Ashley",
                    Notes = "Funny Movie"
                },
                new Movie
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Top Gun Maverick",
                    Year = 2022,
                    Director = "Tom Cruise",
                    Rating = "PG-13",
                    Edited = false,
                    Lent_To = "Me",
                    Notes = "The Best Movie"
                }
                );
        }
    }

}
