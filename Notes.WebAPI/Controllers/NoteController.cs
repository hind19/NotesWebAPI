using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.CQRS.Queries;
using Notes.Application.ViewModels;
using Notes.Domain.Dtos;

namespace Notes.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    // [ApiVersionNeutral]  // For Any API version 
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class NoteController : BaseController
    {
        /// <summary>
        /// Get List of all Notes.
        /// </summary>
        /// <remarks>
        /// Request Sample:
        /// GET /note
        /// </remarks>
        /// <returns>Collection of all Notes.</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">User is not authorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IReadOnlyCollection<NoteVM>>> GetAll()
        {
            var query = new GetAllNotesListQuery(UserId, false);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Gets note details by ID
        /// </summary>
        /// <param name="noteId">Note Id.</param>
        /// <remarks>
        /// Request Sample:
        /// GET /note/NoteID(GUID).
        /// </remarks>
        /// <returns>Single note's details.</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">User is not authorized</response> 
        [HttpGet("{noteId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteDto>> GetDetails(Guid noteId)
        {
            var query = new GetNoteDetailQuery(UserId, noteId);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Greates new Note.
        /// </summary>
        /// <remarks>
        /// Request Sample:
        /// POST /note
        /// {
        ///     title:"notetitle",
        ///     details = "note details"
        /// }
        /// </remarks>
        /// <param name="note">Note Dto with data. </param>
        /// <returns>Id of the created note.</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">User is not authorized</response> 
        [HttpPost]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] NoteDto note)
        {
            var command = new CreateNoteCommand(note.UserId, note.Title, note.Content);
            var result = await Mediator.Send(command);

            return Ok(result);
        }


        /// <summary>
        /// Updates the Note.
        /// </summary>
        /// <remarks>
        /// Request Sample:
        /// POST /note
        /// {
        ///     title:"notetitle",
        ///     details = "note details"
        /// }
        /// </remarks>
        /// <param name="note">Note Dto with data. </param>
        /// <returns>Updated note.</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">User is not authorized</response> 
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteDto>> Update([FromBody] NoteDto note)
        {
            var command = new UpdateNoteCommand(note);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Deletes the specific note
        /// </summary>
        /// <param name="noteId">Id of deleting note.</param>
        /// <returns></returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">User is not authorized</response> 
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid noteId)
        { 
            await Mediator.Send(new DeleteNoteCommand(noteId, UserId));
            
            return NoContent();
        }
    }
}
