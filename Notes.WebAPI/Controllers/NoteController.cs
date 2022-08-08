using Microsoft.AspNetCore.Mvc;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.CQRS.Queries;
using Notes.Application.ViewModels;
using Notes.Domain.Dtos;

namespace Notes.WebAPI.Controllers
{
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<NoteVM>>> GetAll()
        {
            var query = new GetAllNotesListQuery(UserId, false);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{noteId}")]
        public async Task<ActionResult<NoteDto>> GetDetails(Guid noteId)
        {
            var query = new GetNoteDetailQuery(UserId, noteId);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] NoteDto note)
        {
            var command = new CreateNoteCommand(note.UserId, note.Title, note.Content);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<NoteDto>> Update([FromBody] NoteDto note)
        {
            var command = new UpdateNoteCommand(note);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid noteId)
        { 
            await Mediator.Send(new DeleteNoteCommand(noteId, UserId));
            
            return NoContent();
        }
    }
}
