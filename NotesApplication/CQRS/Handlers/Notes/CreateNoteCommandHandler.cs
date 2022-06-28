using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;
using NotesDomain;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content,
                NoteId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.NoteId;
        }
    }
}
