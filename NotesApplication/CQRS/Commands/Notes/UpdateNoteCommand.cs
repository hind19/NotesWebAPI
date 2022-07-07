using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Commands.Notes
{
    public class UpdateNoteCommand : IRequest<NoteDto>
    {
        public UpdateNoteCommand(NoteDto updatedNote)
        {
            UpdatedNote = updatedNote;
        }

        public NoteDto UpdatedNote { get; }
    }
}
