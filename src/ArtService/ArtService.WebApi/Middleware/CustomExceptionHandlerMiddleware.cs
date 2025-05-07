using ArtService.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ArtService.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger = logger;

        private readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task Invoke(HttpContext context, CancellationToken cancellationToken)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, cancellationToken);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            var problem = new ProblemDetails();
            HttpStatusCode code;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    problem.Title = "Validation error";
                    problem.Extensions["errors"] = validationException.Errors;
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    problem.Title = "Resource not found";
                    break;

                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    problem.Title = "Unauthorized";
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    problem.Title = "Internal server error";
                    problem.Detail = "An unexpected error occurred.";
                    _logger.LogError(exception, "Unhandled exception");
                    break;
            }

            problem.Status = (int)code;
            problem.Type = $"https://httpstatuses.com/{(int)code}";
            problem.Extensions["traceId"] = context.TraceIdentifier;

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)code;

            var json = JsonSerializer.Serialize(problem, _serializerOptions);

            return context.Response.WriteAsync(json, cancellationToken);
        }
    }
}
