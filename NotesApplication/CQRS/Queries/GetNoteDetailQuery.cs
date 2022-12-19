using MediatR;
using Notes.Domain.Dtos;

namespace Notes.Application.CQRS.Queries
{
    public class GetNoteDetailQuery : IRequest<NoteDto>
    {
        public GetNoteDetailQuery(Guid noteId, Guid userId)
        {
            NoteId = noteId;
            UserId = userId;
        }

        public Guid NoteId { get; }

        // Not sure about this propertry
        public Guid UserId { get; }
    }
}
