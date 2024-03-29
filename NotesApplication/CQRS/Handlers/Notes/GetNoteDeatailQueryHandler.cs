﻿using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Queries;
using Notes.Application.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    /// <summary>
    /// Provides handler fpr <see cref="GetNoteDetailQuery"/>.
    /// </summary>
    public class GetNoteDeatailQueryHandler : IRequestHandler<GetNoteDetailQuery, NoteDto>
    {
        private readonly INotesRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetNoteDeatailQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Repository instance.</param>
        /// <param name="mapper">Automapper instance.</param>
        public GetNoteDeatailQueryHandler(INotesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<NoteDto> Handle(GetNoteDetailQuery request, CancellationToken cancellationToken)
        {
            var note = await _repository.GetNoteById(request.NoteId);

            return note is null
                ? throw new EntityNotFoundException("Note", request.NoteId)
                : _mapper.Map<NoteDto>(note);
        }
    }
}
