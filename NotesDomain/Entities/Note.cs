namespace Notes.Domain.Entities
{
    /// <summary>
    /// provides Database Model instance <see cref="Note"/>.
    /// </summary>
    public partial class Note
    {
        #region Properties

        /// <summary>
        /// Gets or sets User's Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets Note's Id.
        /// </summary>
        public Guid NoteId { get; set; }

        /// <summary>
        /// Gets or sets Note's Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Note's Content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets Or sets Note's Creation Date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets Note's date of last update.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Note is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Note is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
        #endregion
    }
}
