using Notes.Domain.Dtos;

namespace Notes.Domain.Entities
{
    public partial class Note
    {
        public void Update(NoteDto model)
        {
             Title = model.Title;
            Content = model.Content;
        }
    }
}
