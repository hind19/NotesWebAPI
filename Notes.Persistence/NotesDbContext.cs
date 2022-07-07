using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;

namespace Notes.Persistence
{
    public sealed class NotesDbContext : DbContext
    {
        public DbSet<Note>  Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) 
        {
        }
    }
}
