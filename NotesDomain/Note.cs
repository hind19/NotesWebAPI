 namespace NotesDomain
{
    public class Note
    {

        #region Properties

        public Guid UserId { get; set; }
        
        public Guid NoteId { get; set; }

        public string Title { get; set; }

        public string  Content { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdated { get; set; }


        #endregion
    }
}
