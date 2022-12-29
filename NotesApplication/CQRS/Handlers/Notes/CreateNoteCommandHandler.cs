using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;

namespace Notes.Application.CQRS.Handlers.Notes
{
    /// <summary>
    /// Provides handler for <see cref="CreateNoteCommand"/>.
    /// </summary>
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesRepository _notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNoteCommandHandler"/> class.
        /// </summary>
        /// <param name="notesRepository">Repository instance.</param>
        public CreateNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        /// <inheritdoc/>
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            return await _notesRepository.CreateNote(request.UserId, request.Title, request.Content, cancellationToken);
        }
    }
}
