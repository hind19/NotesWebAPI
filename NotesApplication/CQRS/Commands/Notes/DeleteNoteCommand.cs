using MediatR;

namespace Notes.Application.CQRS.Commands.Notes
{
    public class DeleteNoteCommand : IRequest<Task>
    {
        public DeleteNoteCommand(Guid noteId)
        {
            NoteId = noteId;
        }

        public Guid NoteId { get; set; }
    }
}
