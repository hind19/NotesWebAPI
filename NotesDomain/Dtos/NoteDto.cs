namespace Notes.Domain.Dtos
{
    public class NoteDto
    {
        #region Properties

        public Guid UserId { get; private set; }

        public Guid NoteId { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        #endregion
    }
}
