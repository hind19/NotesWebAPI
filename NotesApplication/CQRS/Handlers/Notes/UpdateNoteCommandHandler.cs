using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, NoteDto>
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandHandler(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task<NoteDto> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var updatedEntnty = await _notesRepository.UpdateNote(request.UpdatedNote, cancellationToken);

            return _mapper.Map<NoteDto>(updatedEntnty);
        }
    }
}
