using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain.Dtos;
using Notes.Domain.Entities;
using System.Linq;

namespace Notes.Persistence.Repositories
{
    internal class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext _context;

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
                IsActive= true,
            };

            await _context.Notes.AddAsync(note, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return note.NoteId;
        }

        public async Task<Note> UpdateNote(NoteDto model, CancellationToken cancellationToken)
        {
            var note = _context.Notes.FirstOrDefault(x => x.NoteId == model.NoteId);

            if(note == null)
            {
                throw new ArgumentException("Note wasn't found");
            }

            note.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return note;
        }

        public async Task DeleteNote(Guid noteId, CancellationToken cancellationToken)
        {
            var note = _context.Notes.FirstOrDefault(x => x.NoteId == noteId);

            if (note == null)
            {
                throw new ArgumentException("Note wasn't found");
            }

            note.SetNoteDeleted();

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyCollection<Note>> GetAllNotesList(Guid userId, bool activeOnly)
        {
            var notes =  _context.Notes.Where(x => x.UserId == userId);
            if(activeOnly)
            {
                notes = notes.Where(x => x.IsActive);
            }

            return notes.ToList().AsReadOnly();

        }

        public async Task<Note> GetNoteById(Guid noteId, Guid userId)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.NoteId == noteId && x.UserId == userId);
        }
    }
}
