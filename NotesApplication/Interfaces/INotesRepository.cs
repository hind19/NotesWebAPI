using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.Interfaces
{
    public interface INotesRepository
    {
        Task<Guid> CreateNote(Guid userId, string title, string content, CancellationToken cancellationToken);

        Task<Note> UpdateNote(NoteDto note, CancellationToken cancellationToken);

        Task DeleteNote(Guid noteId, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<Note>> GetAllNotesList(Guid userId, bool activeOnly);

        Task<Note> GetNoteById(Guid noteId, Guid userId);
    }
}
