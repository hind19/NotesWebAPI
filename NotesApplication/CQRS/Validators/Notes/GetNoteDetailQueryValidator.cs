using FluentValidation;
using Notes.Application.CQRS.Queries;

namespace Notes.Application.CQRS.Validators.Notes
{
    /// <summary>
    /// Provides Validators for <see cref="GetNoteDetailQuery"/>.
    /// </summary>
    internal class GetNoteDetailQueryValidator : AbstractValidator<GetNoteDetailQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetNoteDetailQueryValidator"/> class.
        /// </summary>
        public GetNoteDetailQueryValidator()
        {
            RuleFor(x => x.NoteId).NotEmpty();
        }
    }
}
