using Microsoft.EntityFrameworkCore;
using MyLibrary.Database.Entities;

namespace MyLibrary.Database;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
}