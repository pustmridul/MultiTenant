using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Application.Common.Exceptions.ValidationException;

namespace WEB.Middlewares;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = string.Empty;

        switch (exception)
        {
            case BadRequestException badRequestException:
                code = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;
            case LoginFailedException loginFailedException:
                code = HttpStatusCode.Forbidden;
                result = loginFailedException.Message;
                break;
            case UnauthorizedAccessException unauthorizedAccessException:
                code = HttpStatusCode.Unauthorized;
                result = unauthorizedAccessException.Message;
                break;
            case DataValidationException validationException:
                code = HttpStatusCode.NotAcceptable;

                foreach (var f in validationException.Failures)
                {
                    foreach (var s in f.Value)
                    {
                        result += s + ";";
                    }

                }
                result = JsonSerializer.Serialize(validationException.Failures);
                break;
            case NotFoundException _:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty)

        {
            result = exception.Message;
            BuildException(exception.InnerException, result);
            result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                exception = JsonSerializer.Serialize(exception)
            });
        }

        return context.Response.WriteAsync(result);
    }

    void BuildException(Exception? ex, string message)
    {
        if (ex?.InnerException != null)
        {
            message += ex.Message;
            BuildException(ex.InnerException, message);
        }
    }
}




public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}

