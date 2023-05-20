using MediatR;

namespace Notes.Application.CQRS.Commands.Notes
{
    /// <summary>
    /// Provides command for deleting Note instance.
    /// </summary>
    public sealed class DeleteNoteCommand : IRequest<Task>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNoteCommand"/> class.
        /// </summary>
        /// <param name="noteId">Note's Id.</param>
        public DeleteNoteCommand(Guid noteId)
        {
            NoteId = noteId;
        }

        /// <summary>
        /// Gets Note's Id.
        /// </summary>
        public Guid NoteId { get; }
    }
}
