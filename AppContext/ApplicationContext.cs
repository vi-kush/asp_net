using dotnet.Models;
using Microsoft.EntityFrameworkCore;

// dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet add package Microsoft.EntityFrameworkCore
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// dotnet add package Microsoft.EntityFrameworkCore.Tools

namespace dotnet.AppContext
{

    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {

        // Default schema for the database context
        private const string DefaultSchema = "bookapi";


       // DbSet to represent the collection of books in our database
        public DbSet<BookModel> Books { get; set; }

        // Constructor to configure the database context

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(DefaultSchema);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}