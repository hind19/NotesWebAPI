using System.ComponentModel.DataAnnotations;

namespace Notes.Domain.Dtos
{
    public class NoteDto
    {
        #region Properties

        public Guid UserId { get; set; }

        public Guid NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        #endregion
    }
}
