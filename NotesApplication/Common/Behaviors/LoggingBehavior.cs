using MediatR;
using Notes.Application.Interfaces;
using Serilog;

namespace Notes.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _userService;

        public LoggingBehavior(ICurrentUserService userService)
        {
            _userService = userService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information("Notes Request {Name} {@UserId} {@Request}", requestName, _userService.GetUserId(), request);

            var response = await next();

            return response;
        }
    }
}
