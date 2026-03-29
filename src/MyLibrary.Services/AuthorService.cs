using Microsoft.EntityFrameworkCore;
using MyLibrary.Database;
using MyLibrary.Database.Entities;
using MyLibrary.Domain.Authors;
using MyLibrary.Domain.Authors.Dto;
using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Services;

public class AuthorService : IAuthorService
{
    private readonly LibraryDbContext _dbContext;

    public AuthorService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(CreateAuthorDto author)
    {
        var entity = new AuthorEntity
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
            SurName = author.SurName,
            Biography = author.Biography,
            BornedAt = author.BornedAt,
            DiedAt = author.DiedAt
        };

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<AuthorDto> GetAsync(int id)
    {
        var author = await _dbContext
            .Set<AuthorEntity>()
            .Where(author => author.Id == id)
            .Select(author => new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                SurName = author.SurName,
                BornedAt = author.BornedAt,
                DiedAt = author.DiedAt
            })
            .FirstOrDefaultAsync();

        return author ?? throw new NotFoundException();
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var authors = await _dbContext
            .Set<AuthorEntity>()
            .Select(author => new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                SurName = author.SurName,
                BornedAt = author.BornedAt,
                DiedAt = author.DiedAt
            })
            .ToListAsync();

        return authors;
    }

    public async Task UpdateAsync(UpdateAuthorDto request)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(author => author.Id == request.Id);
        if (author is null)
            throw new NotFoundException();

        author.FirstName = request.FirstName;
        author.LastName = request.LastName;
        author.SurName = request.SurName;
        author.Biography = request.Biography;
        author.BornedAt = request.BornedAt;
        author.DiedAt = request.DiedAt;

        _dbContext.Update(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _dbContext.Authors
            .FirstOrDefaultAsync(author => author.Id == id);

        if (author is null)
            throw new NotFoundException();

        _dbContext.Remove(author);
        await _dbContext.SaveChangesAsync();
    }
}