﻿using FluentValidation;
using Notes.Application.CQRS.Commands.Notes;

namespace Notes.Application.CQRS.Validators.Notes
{
    /// <summary>
    /// Provides Validators for <see cref="DeleteNoteCommand"/>.
    /// </summary>
    internal class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNoteCommandValidator"/> class.
        /// </summary>
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.NoteId)
                .NotEmpty();
        }
    }
}
