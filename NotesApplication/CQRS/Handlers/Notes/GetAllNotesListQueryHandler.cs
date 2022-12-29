using AutoMapper;
using MediatR;
using Notes.Application.CQRS.Queries;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Handlers.Notes
{
    /// <summary>
    /// Provides handler fpr <see cref="GetAllNotesListQuery"/>.
    /// </summary>
    public class GetAllNotesListQueryHandler : IRequestHandler<GetAllNotesListQuery, IReadOnlyCollection<NoteDto>>
    {
        private INotesRepository _repository;
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllNotesListQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Repository instance.</param>
        /// <param name="mapper">Automapper instance.</param>
        public GetAllNotesListQueryHandler(INotesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<NoteDto>> Handle(GetAllNotesListQuery request, CancellationToken cancellationToken)
        {
            var notes = await _repository.GetAllNotesList(request.UserId, request.ActiveOnly);

            return _mapper.Map<IReadOnlyCollection<NoteDto>>(notes);
        }
    }
}
