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

        public DbSet<FormSubmission> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FormSubmission>().HasData(

                new FormSubmission
                {
                    ApplicationID = 1,
                    Category = "Family",
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
                    ApplicationID = 2,
                    Category = "Family",
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
                    ApplicationID = 3,
                    Category = "Action/Adventure",
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
