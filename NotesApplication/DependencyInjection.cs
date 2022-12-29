using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;

namespace Notes.Application
{
    /// <summary>
    /// Provides the dependency Injections registrtation.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method which adds Pipeline behaviors to pipeline.
        /// </summary>
        /// <param name="services">Collection of services.</param>
        /// <returns>the instance of <see cref="IServiceCollection"/>. </returns>
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
