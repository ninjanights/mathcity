using System.Net;
using Microsoft.AspNetCore.Mvc;
using MathCity.Application.Common.Exceptions;

namespace MathCity.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var statusCode = ex switch
            {
                ValidationException => StatusCodes.Status400BadRequest,

                UnauthorizedException => StatusCodes.Status401Unauthorized,

                NotFoundException => StatusCodes.Status404NotFound,

                ConflictException => StatusCodes.Status409Conflict,

                _ => StatusCodes.Status500InternalServerError
            };

            await HandleExceptionAsync(context, ex, statusCode);
        }
    }

    private static async Task HandleExceptionAsync(
    HttpContext context,
    Exception exception,
    int statusCode)
    {
        var problem = new ProblemDetails
        {
            Title = exception.Message,
            Status = statusCode,
            Detail = statusCode == 500
          ? "An unexpected error occurred."
          : exception.Message,
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(problem);
    }
}