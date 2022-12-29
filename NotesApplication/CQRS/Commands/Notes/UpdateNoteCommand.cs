using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Commands.Notes
{
    /// <summary>
    /// Privides command for updating Note.
    /// </summary>
    public sealed class UpdateNoteCommand : IRequest<NoteDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateNoteCommand"/> class.
        /// </summary>
        /// <param name="updatedNote">Note's DTO for update.</param>
        public UpdateNoteCommand(NoteDto updatedNote)
        {
            UpdatedNote = updatedNote;
        }

        /// <summary>
        /// Gets Dto for update.
        /// </summary>
        public NoteDto UpdatedNote { get; }
    }
}
