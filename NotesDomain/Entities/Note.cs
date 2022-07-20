namespace Notes.Domain.Entities
{
    public partial class Note
    {

        #region Properties

        public Guid UserId { get; set; }

        public Guid NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


        #endregion
    }
}
