namespace Notes.Application.Interfaces
{
    /// <summary>
    /// provides methods for User feature.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets Current User's Id.
        /// </summary>
        /// <returns>Current User's Id.</returns>
        Guid GetUserId();
    }
}
