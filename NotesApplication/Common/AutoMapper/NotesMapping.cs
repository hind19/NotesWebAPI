using AutoMapper;
using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.Common.AutoMapper
{
    /// <summary>
    /// Mapping profiles for Notes.
    /// </summary>
    public class NotesMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesMapping"/> class.
        /// </summary>
        public NotesMapping()
        {
            NotesMaps();
        }

        private void NotesMaps()
        {
            CreateMap<Note, NoteDto>()
               .ReverseMap();
        }
    }
}
