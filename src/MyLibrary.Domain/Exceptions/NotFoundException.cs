namespace MyLibrary.Domain.Exceptions;

public class NotFoundException : BaseClientException
{
    public NotFoundException() : base("Объект не найден")
    {
    }
}