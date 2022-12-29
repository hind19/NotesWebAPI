using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;

namespace Notes.Application.CQRS.Handlers.Notes
{
    /// <summary>
    /// Provides handler for <see cref="DeleteNoteCommand"/>.
    /// </summary>
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Task>
    {
        private readonly INotesRepository _notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNoteCommandHandler"/> class.
        /// </summary>
        /// <param name="notesRepository">Repository Instance.</param>
        public DeleteNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        /// <inheritdoc/>
        public async Task<Task> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await _notesRepository.DeleteNote(request.NoteId, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
