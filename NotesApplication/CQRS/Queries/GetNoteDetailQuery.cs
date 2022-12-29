using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Queries
{
    /// <summary>
    /// Provides the filtered query by Notes Id.
    /// </summary>
    public class GetNoteDetailQuery : IRequest<NoteDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetNoteDetailQuery"/> class.
        /// </summary>
        /// <param name="noteId">Note Id.</param>
        public GetNoteDetailQuery(Guid noteId)
        {
            NoteId = noteId;
        }

        /// <summary>
        /// Gets Note Id.
        /// </summary>
        public Guid NoteId { get; }
    }
}
