using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Queries;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class GetNoteDeatailQueryHandler : IRequestHandler<GetNoteDetailQuery, NoteDto>
    {
        private INotesRepository _repository;
        private IMapper _mapper;

        public GetNoteDeatailQueryHandler(INotesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NoteDto> Handle(GetNoteDetailQuery request, CancellationToken cancellationToken)
        {
            var note = await _repository.GetNoteById(request.NoteId, request.UserId);

            return _mapper.Map<NoteDto>(note);
        }
    }
}
