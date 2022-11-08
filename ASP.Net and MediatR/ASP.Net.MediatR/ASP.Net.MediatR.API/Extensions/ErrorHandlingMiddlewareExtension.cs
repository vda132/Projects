using ASP.Net.MediatR.API.Middlewares;

namespace ASP.Net.MediatR.API.Extensions;

public static class ErrorHandlingMiddlewareExtension
{
    public static IApplicationBuilder UseErrorMiddleware(
    this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
