namespace Notes.WebAPI.Middleware
{
    /// <summary>
    /// Extension methods for Custom Exception handling middleware.
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Method adds middleware to pipeline.
        /// </summary>
        /// <param name="builder">The instance of application builder. </param>
        /// <returns>The instance of <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
