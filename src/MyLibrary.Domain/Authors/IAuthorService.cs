using MyLibrary.Domain.Authors.Dto;

namespace MyLibrary.Domain.Authors;

public interface IAuthorService
{
    Task<int> CreateAsync(CreateAuthorDto author);

    Task<AuthorDto> GetAsync(int id);

    Task DeleteAsync(int id);

    Task UpdateAsync(UpdateAuthorDto request);
}