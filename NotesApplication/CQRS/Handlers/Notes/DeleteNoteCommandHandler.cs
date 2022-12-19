using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Task>
    {
        private readonly INotesRepository _notesRepository;

        public DeleteNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<Task> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await _notesRepository.DeleteNote(request.NoteId, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
