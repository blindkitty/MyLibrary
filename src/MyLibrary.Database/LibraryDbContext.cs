using Microsoft.EntityFrameworkCore;
using MyLibrary.Database.Entities;

namespace MyLibrary.Database;

public class LibraryDbContext : DbContext
{
    public DbSet<AuthorEntity> Authors { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }
}