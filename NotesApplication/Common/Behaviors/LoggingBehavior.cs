using MediatR;
using Notes.Application.Interfaces;
using Serilog;

namespace Notes.Application.Common.Behaviors
{
    /// <summary>
    /// Provides logging behavior.
    /// </summary>
    /// <typeparam name="TRequest">Request.</typeparam>
    /// <typeparam name="TResponse">Response.</typeparam>
    public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="userService">the user service instance.</param>
        public LoggingBehavior(ICurrentUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Handler for logging bahavior.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="next">next pipeline handler.</param>
        /// <returns>Returns Response>.</returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information($"Notes Request {requestName} {_userService.GetUserId()} {request}");

            var response = await next();

            return response;
        }
    }
}
