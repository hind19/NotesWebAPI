namespace Notes.Domain.Dtos
{
    /// <summary>
    /// Provides DTO for Note instance.
    /// </summary>
    public class NoteDto
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
        /// Gets or sets  Notes'es Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets Or sets Notes'es  Content.
        /// </summary>
        public string Content { get; set; }

        #endregion
    }
}
