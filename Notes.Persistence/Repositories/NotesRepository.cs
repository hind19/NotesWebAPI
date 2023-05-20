using Microsoft.EntityFrameworkCore;
using Notes.Application.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Persistence.Repositories
{
    internal class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext _context;
        private const string Note = "Note";

        public NotesRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateNote(Guid userId, string title, string content, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = userId,
                Title = title,
                Content = content,
                NoteId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                IsActive = true,
            };

            await _context.Notes.AddAsync(note, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return note.NoteId;
        }

        public async Task<Note> UpdateNote(NoteDto note, CancellationToken cancellationToken)
        {
            var noteForUpdate = _context.Notes.FirstOrDefault(x => x.NoteId == note.NoteId);

            if (noteForUpdate == null)
            {
                throw new EntityNotFoundException(Note, note.NoteId);
            }

            noteForUpdate.Update(note);
            await _context.SaveChangesAsync(cancellationToken);

            return noteForUpdate;
        }

        public async Task DeleteNote(Guid noteId, CancellationToken cancellationToken)
        {
            var note = _context.Notes.FirstOrDefault(x => x.NoteId == noteId);

            if (note == null)
            {
                throw new EntityNotFoundException(Note, noteId);
            }

            note.SetNoteDeleted();

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotesList(Guid userId, bool activeOnly)
        {
             await Task.Yield();

            var notes = _context.Notes.Where(x => x.UserId == userId);
            if (activeOnly)
            {
                notes = notes.Where(x => x.IsActive);
            }

            return notes.ToList().AsReadOnly();

        }

        public async Task<Note> GetNoteById(Guid noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.NoteId == noteId);
        }
    }
}
