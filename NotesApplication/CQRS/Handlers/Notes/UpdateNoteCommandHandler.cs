using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    /// <summary>
    /// Provides handler fpr <see cref="UpdateNoteCommand"/>.
    /// </summary>
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, NoteDto>
    {
        private readonly INotesRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateNoteCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Repository instance.</param>
        /// <param name="mapper">Automapper instance.</param>
        public UpdateNoteCommandHandler(INotesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<NoteDto> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var updatedEntnty = await _repository.UpdateNote(request.UpdatedNote, cancellationToken);

            return _mapper.Map<NoteDto>(updatedEntnty);
        }
    }
}
