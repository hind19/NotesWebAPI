using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using NotesDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence
{
    public sealed class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note>  Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) 
        {
        }
    }
}
