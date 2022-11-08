using ASP.Net.MediatR.CRUD.Result;
using System.Text.Json;

namespace ASP.Net.MediatR.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            var response = new ExecResult
            {
                HasErrors = true,
                IsSystemError = true,
                Errors = new string[] { ex.Message }
            };

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
