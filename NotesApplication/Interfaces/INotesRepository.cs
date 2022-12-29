using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.Interfaces
{
    /// <summary>
    /// Provides methods for working with repository.
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Create new Note.
        /// </summary>
        /// <param name="userId">The User's Id.</param>
        /// <param name="title">The Note's Title.</param>
        /// <param name="content">The Note;s Content.</param>
        /// <param name="cancellationToken">The Cancellation Token.</param>
        /// <returns>Result of asynchronous operation.</returns>
        Task<Guid> CreateNote(Guid userId, string title, string content, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the Note.
        /// </summary>
        /// <param name="note">The DTO for updaete.</param>
        /// <param name="cancellationToken">The Cancellation Token.</param>
        /// <returns>Result of asynchronous operation.</returns>
        Task<Note> UpdateNote(NoteDto note, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the Note by Id.
        /// </summary>
        /// <param name="noteId">The Note's Id.</param>
        /// <param name="cancellationToken">The Cancellation token.</param>
        /// <returns>Result of asynchronous operation.</returns>
        Task DeleteNote(Guid noteId, CancellationToken cancellationToken);

        /// <summary>
        /// Gets ReadOnly collection of all notes related to the User.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <param name="activeOnly">Filter flag for Active notes only.</param>
        /// <returns>ReadOnle Collection of Notes.</returns>
        Task<IReadOnlyCollection<Note>> GetAllNotesList(Guid userId, bool activeOnly);

        /// <summary>
        /// Gets Note by Id.
        /// </summary>
        /// <param name="noteId">Note's Id.</param>
        /// <returns>Note.</returns>
        Task<Note> GetNoteById(Guid noteId);
    }
}
