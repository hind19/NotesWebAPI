using FluentValidation;
using Notes.Application.CQRS.Commands.Notes;

namespace Notes.Application.CQRS.Validators.Notes
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
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
