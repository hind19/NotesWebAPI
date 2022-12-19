using FluentValidation;
using Notes.Application.CQRS.Commands.Notes;

namespace Notes.Application.CQRS.Validators.Notes
{
    internal class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            //TODO: Ass UserId to delete command
            //RuleFor(deleteNoteCommand => deleteNoteCommand.UserId)
            //      .NotEmpty();
            RuleFor(deleteNoteCommand => deleteNoteCommand.NoteId)
                .NotEmpty();
        }
    }
}
