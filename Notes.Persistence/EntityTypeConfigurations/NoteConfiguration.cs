using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.NoteId);
            builder.HasIndex(x => x.NoteId).IsUnique();

            builder.Property(x => x.Title)
                .HasMaxLength(250);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

        }
    }
}
