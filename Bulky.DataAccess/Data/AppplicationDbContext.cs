
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Horror", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Mystery", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Romance", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Thriller", DisplayOrder = 8 },
                new Category { Id = 9, Name = "Western", DisplayOrder = 9 },
                new Category { Id = 10, Name = "Disaster", DisplayOrder = 10 }
                );
        }
    }
}

