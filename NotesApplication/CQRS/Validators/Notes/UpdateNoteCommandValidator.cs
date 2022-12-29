using FluentValidation;
using Notes.Application.CQRS.Commands.Notes;

namespace Notes.Application.CQRS.Validators.Notes
{
    /// <summary>
    /// Provides Validators for <see cref="UpdateNoteCommand"/>.
    /// </summary>
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateNoteCommandValidator"/> class.
        /// </summary>
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.UpdatedNote.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(updateNoteCommand => updateNoteCommand.UpdatedNote.Content)
                .MaximumLength(8000);

            RuleFor(updateNoteCommand => updateNoteCommand.UpdatedNote.UserId)
                .NotEmpty();

            RuleFor(updateNoteCommand => updateNoteCommand.UpdatedNote.NoteId)
                .NotEmpty();
        }
    }
}
