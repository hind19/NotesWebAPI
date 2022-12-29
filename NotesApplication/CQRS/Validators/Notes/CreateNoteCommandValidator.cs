using FluentValidation;
using Notes.Application.CQRS.Commands.Notes;

namespace Notes.Application.CQRS.Validators.Notes
{
    /// <summary>
    /// Provides Validators for <see cref="CreateNoteCommand"/>.
    /// </summary>
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNoteCommandValidator"/> class.
        /// </summary>
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(createNoteCommand => createNoteCommand.Content)
                .MaximumLength(8000);

            RuleFor(createNoteCommand => createNoteCommand.UserId)
                .NotEmpty();
        }
    }
}
