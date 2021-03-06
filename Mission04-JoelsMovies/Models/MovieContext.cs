using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04_JoelsMovies.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Family" },
                new Category { CategoryID = 2, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 3, CategoryName = "Comedy" },
                new Category { CategoryID = 4, CategoryName = "Drama" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
                );
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    Title = "Cinderella",
                    Year = "2015",
                    Director = "Kenneth Branagh",
                    Rating = "PG",
                    CategoryID = 1,
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    Title = "Spider-Man",
                    Year = "2002",
                    Director = "Sam Raimi",
                    Rating = "PG-13",
                    CategoryID = 2,
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    Title = "Spider-Man: Into the Spider-Verse",
                    Year = "2018",
                    Director = "Peter Ramsey, Bob Persichetti, Rodney Rothman",
                    Rating = "PG",
                    CategoryID = 2,
                    Edited = false,
                    Lent_to = "",
                    Notes = ""
                }
                );
            
        }
    }
}
