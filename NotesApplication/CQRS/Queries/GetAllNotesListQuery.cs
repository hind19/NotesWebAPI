using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Queries
{
    public class GetAllNotesListQuery : IRequest<IReadOnlyCollection<NoteDto>>
    {
        public GetAllNotesListQuery(Guid userId, bool activeOnly)
        {
            UserId = userId;
            ActiveOnly = activeOnly;
        }

        public Guid UserId { get; }

        public bool ActiveOnly { get; }
    }
}
