namespace Notes.Application.ViewModels
{
    /// <summary>
    /// Provides Note View model.
    /// </summary>
    public sealed class NoteVM
    {
        #region Properties

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the Note Id.
        /// </summary>
        public Guid NoteId { get; set; }

        /// <summary>
        /// Gets or sets  the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public string Content { get; set; }

        #endregion
    }
}
