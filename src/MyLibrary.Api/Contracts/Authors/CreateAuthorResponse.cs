namespace MyLibrary.Api.Contracts.Authors;

public class CreateAuthorResponse
{
    public int Id { get; }

    public CreateAuthorResponse(int id)
    {
        Id = id;
    }
}