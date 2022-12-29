using MediatR;

namespace Notes.Application.CQRS.Commands.Notes
{
    /// <summary>
    /// Provades command for creating note instanse.
    /// </summary>
    public sealed class CreateNoteCommand : IRequest<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNoteCommand"/> class.
        /// </summary>
        /// <param name="userId">UserId.</param>
        /// <param name="title">Note's Title.</param>
        /// <param name="content">Note's Content.</param>
        public CreateNoteCommand(Guid userId, string title, string content)
        {
            UserId = userId;
            Title = title;
            Content = content;
        }

        /// <summary>
        /// Gets user's Id.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets Note's Titile.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets Note's Content.
        /// </summary>
        public string Content { get; }
    }
}
