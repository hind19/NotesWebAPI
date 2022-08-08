using MediatR;

namespace Notes.Application.CQRS.Commands.Notes
{
    public class DeleteNoteCommand : IRequest<Task>
    {
        public DeleteNoteCommand(Guid noteId, Guid userId)
        {
            NoteId = noteId;
            UserId = userId;
        }

        public Guid NoteId { get; }

        public Guid UserId { get; }
    }
}
