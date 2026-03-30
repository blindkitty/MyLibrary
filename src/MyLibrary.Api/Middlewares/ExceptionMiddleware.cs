using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(BaseClientException ex)
        {
            httpContext.Response.StatusCode = (int)ex.StatusCode;
            httpContext.Response.ContentType = "text/plain";
            await httpContext.Response.WriteAsync(ex.Message);
        }
    }
}