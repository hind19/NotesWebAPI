using System.Runtime.Serialization;

namespace Notes.WebAPI.RequestModels
{
    /// <summary>
    /// Request contract for new note creation.
    /// </summary>
    [DataContract]
    public class CreateNoteRequestModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets User's Id.
        /// </summary>
        public Guid UserId { get; set; }

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
