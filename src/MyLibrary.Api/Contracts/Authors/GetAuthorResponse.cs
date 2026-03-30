namespace MyLibrary.Api.Contracts.Authors;

public class GetAuthorResponse
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? SurName { get; set; }

    public DateTime BornedAt { get; set; }

    public DateTime? DiedAt { get; set; }
}