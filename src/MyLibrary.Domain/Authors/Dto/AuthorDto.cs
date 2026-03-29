namespace MyLibrary.Domain.Authors.Dto;

public class AuthorDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? SurName { get; set; }

    public DateTime BornedAt { get; set; }

    public DateTime? DiedAt { get; set; }
}