using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Queries;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    public class GetAllNotesListQueryHandler : IRequestHandler<GetAllNotesListQuery, IReadOnlyCollection<NoteDto>>
    {
        private INotesRepository _repository;
        private IMapper _mapper;

        public GetAllNotesListQueryHandler(INotesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<NoteDto>> Handle(GetAllNotesListQuery request, CancellationToken cancellationToken)
        {
            var notes = await _repository.GetAllNotesList(request.UserId, request.ActiveOnly);
            
            return _mapper.Map<IReadOnlyCollection<NoteDto>>(notes);
        }
    }
}
