using MediatR;
using Notes.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
