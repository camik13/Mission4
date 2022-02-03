using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieSubmissionContext : DbContext
    {
        // Constructor
        public MovieSubmissionContext (DbContextOptions<MovieSubmissionContext> options) : base (options)
        {
             // Leave blank for now
        }

        public DbSet<FormSubmission>Responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1,CategoryName="Action/Adventure"},
                new Category { CategoryID=2, CategoryName="Comedy"},
                new Category { CategoryID=3, CategoryName="Drama"},
                new Category { CategoryID=4, CategoryName="Family"},
                new Category { CategoryID=5, CategoryName="Horror/Suspense"},
                new Category { CategoryID=6, CategoryName="Miscellaneous"},
                new Category { CategoryID=7, CategoryName="Television"},
                new Category { CategoryID=8, CategoryName="VHS"}
                );

            mb.Entity<FormSubmission>().HasData(

                new FormSubmission
                {
                    MovieID = 1,
                    CategoryID = 4,
                    Title = "Moana",
                    Year = 2016,
                    Director = "Ron Clements and John Musker",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""

                },

                new FormSubmission
                {
                    MovieID = 2,
                    CategoryID = 4,
                    Title = "Cinderella",
                    Year = 2015,
                    Director = "Kenneth Branagh",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""

                },

                new FormSubmission
                {
                    MovieID = 3,
                    CategoryID = 1,
                    Title = "Spider-Man: No Way Home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""

                }
            );
            
        }
    }
}
