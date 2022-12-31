using Notes.Domain.Dtos;

namespace Notes.Domain.Entities
{
    /// <summary>
    /// Provides Note instance.
    /// </summary>
    public partial class Note
    {
        /// <summary>
        /// Updates Note instance method.
        /// </summary>
        /// <param name="model">Update model.</param>
        public void Update(NoteDto model)
        {
             Title = model.Title;
             Content = model.Content;
        }

        /// <summary>
        /// Marks Note as deleted.
        /// </summary>
        public void SetNoteDeleted()
        {
            IsActive = false;
            IsDeleted = true;
        }
    }
}
