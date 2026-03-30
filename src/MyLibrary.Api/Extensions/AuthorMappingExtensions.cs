using MyLibrary.Api.Contracts.Authors;
using MyLibrary.Domain.Authors.Dto;

namespace MyLibrary.Api.Extensions;

public static class AuthorMappingExtensions
{
    public static CreateAuthorDto ToDto(this CreateAuthorRequest request)
    {
        return new CreateAuthorDto()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            SurName = request.SurName,
            Biography = request.Biography,
            BornedAt = request.BornedAt,
            DiedAt = request.DiedAt
        };
    }

    public static GetAuthorResponse ToResponse(this AuthorDto dto)
    {
        return new GetAuthorResponse
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            SurName = dto.SurName,
            BornedAt = dto.BornedAt,
            DiedAt = dto.DiedAt
        };
    }

    public static UpdateAuthorDto ToDto(this UpdateAuthorRequest request)
    {
        return new UpdateAuthorDto
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            SurName = request.SurName,
            Biography = request.Biography,
            BornedAt = request.BornedAt,
            DiedAt = request.DiedAt
        };
    }
}