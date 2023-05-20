using System.Net;
using System.Text.Json;
using FluentValidation;
using Notes.Application.Common;
using Notes.Application.Exceptions;

namespace Notes.WebAPI.Middleware
{
    /// <summary>
    /// Custom middleware for exceptions handling.
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The request delegate.</param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invockes next element of pipeline.
        /// </summary>
        /// <param name="context"> Current Http context.</param>
        /// <returns>Instance of <see cref="Task"/>.</returns>
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case EntityNotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
            }

            context.Response.ContentType = Constants.AppJson;
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(message))
            {
                message = JsonSerializer.Serialize(new { error = ex.Message, stacktrace = ex.ToString() });
            }

            return context.Response.WriteAsync(message);
        }
    }
}
