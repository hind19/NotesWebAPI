using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesRepository _notesRepository;

        public CreateNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            return await _notesRepository.CreateNote(request.UserId, request.Title, request.Content, cancellationToken);
        }
    }
}
