using MediatR;

namespace Notes.Application.CQRS.Commands.Notes
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public CreateNoteCommand(Guid userId, string title, string content)
        {
            UserId = userId;
            Title = title;
            Content = content;
        }

        public Guid UserId { get; }

        public string Title { get; }

        public string Content { get; }
    }
}
