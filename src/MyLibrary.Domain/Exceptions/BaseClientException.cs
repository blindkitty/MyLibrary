using System.Net;

namespace MyLibrary.Domain.Exceptions;

public abstract class BaseClientException : Exception
{
    public HttpStatusCode StatusCode { get; }

    protected BaseClientException()
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    protected BaseClientException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    protected BaseClientException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}