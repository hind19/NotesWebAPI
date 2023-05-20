using System.Security.Claims;
using Notes.Application.Interfaces;

namespace Notes.WebAPI.Services
{
    /// <summary>
    /// servicw for current user.
    /// </summary>
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUserService"/> class.
        /// </summary>
        /// <param name="contextAccessor"> Http context accessor.</param>
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetUserId()
        {
            var id = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return string.IsNullOrWhiteSpace(id)
                ? Guid.Empty
                : Guid.Parse(id);
        }
    }
}
