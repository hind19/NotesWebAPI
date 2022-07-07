using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.Interfaces
{
    public interface INotesRepository
    {
        Task<Guid> CreateNote(Guid userId, string title, string content);

        Task<Note> UpdateNote(NoteDto note);
    }
}
