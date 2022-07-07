using MediatR;
using Notes.Domain.Dtos;


namespace Notes.Application.CQRS.Queries
{
    public class GetAllNotesListQuery : IRequest<IReadOnlyCollection<NoteDto>>
    {

        public Guid UserId { get; set; }

        public bool ActiveOnly { get; set; }
    }
}
