using AutoMapper;
using Notes.Domain.Dtos;
using Notes.Domain.Entities;

namespace Notes.Application.Common.AutoMapper
{
    internal class NotesMapping : Profile
    {
        public NotesMapping()
        {
            CreateMap<Note, NoteDto>()
                .ReverseMap();
        }
    }
}
