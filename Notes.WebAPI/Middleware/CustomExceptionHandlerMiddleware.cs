using FluentValidation;
using Notes.Application.Common;
using Notes.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace Notes.WebAPI.Middleware
{
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
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = string.Empty;   

            switch(ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case EntityNotFoundException notFoundException:
                    code=HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
            }

            context.Response.ContentType = Constants.AppJson;
            context.Response.StatusCode = (int)code;

            if(string.IsNullOrEmpty(message))
            {
                message = JsonSerializer.Serialize(new { error = ex.Message, stacktrace = ex.ToString() });
            }

            return context.Response.WriteAsync(message);
        }
    }
}
