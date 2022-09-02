using FluentValidation;
using Notes.Application.CQRS.Queries;

namespace Notes.Application.CQRS.Validators.Notes
{
    internal class GetNoteDetailQueryValidator : AbstractValidator<GetNoteDetailQuery>
    {
        public GetNoteDetailQueryValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty();
        }
    }
}
