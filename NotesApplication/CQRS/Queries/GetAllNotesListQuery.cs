using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Queries
{
    /// <summary>
    /// Provides query for all Notes.
    /// </summary>
    public class GetAllNotesListQuery : IRequest<IReadOnlyCollection<NoteDto>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllNotesListQuery"/> class.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="activeOnly">Filer parameter for active only notes.</param>
        public GetAllNotesListQuery(Guid userId, bool activeOnly = false)
        {
            UserId = userId;
            ActiveOnly = activeOnly;
        }

        /// <summary>
        /// Gets User Id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets a value indicating whether ActiveOnly filter flag is set.
        /// </summary>
        public bool ActiveOnly { get; }
    }
}
