using Notes.Application.Interfaces;
using Notes.Domain.Dtos;
using Notes.Domain.Entities;


namespace Notes.Persistence.Repositories
{
    internal class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext _context;

        public NotesRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateNote(Guid userId, string title, string content)
        {
            var note = new Note
            {
                UserId = userId,
                Title = title,
                Content = content,
                NoteId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
            };

            await _context.Notes.AddAsync(note, CancellationToken.None);
            await _context.SaveChangesAsync(CancellationToken.None);

            return note.NoteId;
        }

        public async Task<Note> UpdateNote(NoteDto model)
        {
            var note = _context.Notes.FirstOrDefault(x => x.NoteId == model.NoteId);

            if(note == null)
            {
                throw new ArgumentException("Note wasn't found");
            }

            note.Update(model);
            await _context.SaveChangesAsync(CancellationToken.None);

            return note;
        }
    }
}
