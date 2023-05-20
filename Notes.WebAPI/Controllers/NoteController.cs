using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.CQRS.Commands.Notes;
using Notes.Application.CQRS.Queries;
using Notes.Application.Exceptions;
using Notes.Application.ViewModels;
using Notes.Domain.Dtos;
using Notes.WebAPI.RequestModels;

namespace Notes.WebAPI.Controllers
{
    /// <summary>
    /// Controller providing API actions for Notes.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]/[action]")]
    public class NoteController : BaseController
    {
        /// <summary>
        /// Get List of all Notes.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="activeOnly">Flag if we should take active only notes.</param>
        /// <remarks>
        /// Request Sample:
        /// GET /note  .
        /// </remarks>
        /// <returns>Collection of all Notes.</returns>
        /// <response code = "200">Success.</response>
        /// <response code = "401">User is not authorized.</response>
        [HttpGet("{userId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IReadOnlyCollection<NoteVM>>> GetAll(Guid userId, bool activeOnly = false)
        {
            var query = new GetAllNotesListQuery(userId, activeOnly);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Gets note details by ID.
        /// </summary>
        /// <param name="noteId">Note Id.</param>
        /// <remarks>
        /// Request Sample:
        /// GET /note/NoteID(GUID).
        /// </remarks>
        /// <returns>Single note's details.</returns>
        /// <response code = "200">Success.</response>
        /// <response code = "401">User is not authorized.</response>
        [HttpGet("{noteId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoteDto>> GetDetails(Guid noteId)
        {
            try
            {
                var query = new GetNoteDetailQuery(noteId);
                var result = await Mediator.Send(query);

                return Ok(result);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
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
        /// }.
        /// </remarks>
        /// <param name="note">Note Dto with data. </param>
        /// <returns>Id of the created note.</returns>
        /// <response code = "200">Success.</response>
        /// <response code = "401">User is not authorized.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteRequestModel note)
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
        /// }.
        /// </remarks>
        /// <param name="note">Note Dto with data. </param>
        /// <returns>Updated note.</returns>
        /// <response code = "200">Success.</response>
        /// <response code = "401">User is not authorized.</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoteDto>> Update([FromBody] NoteDto note)
        {
            try
            {
                var command = new UpdateNoteCommand(note);
                var result = await Mediator.Send(command);

                return Ok(result);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        /// <summary>
        /// Deletes the specific note.
        /// </summary>
        /// <param name="noteId">Id of deleting note.</param>
        /// <response code = "200">Success.</response>
        /// <response code = "401">User is not authorized.</response>
        /// <returns>No Content.</returns>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid noteId)
        {
            try
            {
                _ = await Mediator.Send(new DeleteNoteCommand(noteId));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }

            return Ok();
        }
    }
}
