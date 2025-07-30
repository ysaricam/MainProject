using MainProject.Application.Features.Users.Commands.CreateUser;
using MainProject.Application.Features.Users.Commands.DeleteUser;
using MainProject.Application.Features.Users.Commands.UpdateUser;
using MainProject.Application.Features.Users.Commands.AssignRoleToUser;
using MainProject.Application.Features.Users.Queries.GetAllUsers;
using MainProject.Application.Features.Users.Queries.GetUserById;
using MainProject.Application.Features.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MainProject.Application.Features.Users.Commands.LoginUser;

namespace MainProject.Presentation.Controllers
{
    /// <summary>
    /// DTO for the assign role request
    /// </summary>
    public class AssignRoleRequest
    {
        public Guid RoleId { get; set; }
    }

    /// <summary>
    /// Controller for managing users
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        /// <returns>The user details</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="command">User creation details</param>
        /// <returns>The ID of the created user</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="id">The ID of the user to update</param>
        /// <param name="command">The updated user details</param>
        /// <returns>No content if successful</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                command.Id = id;
            }

            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Assigns a role to a user
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="request">The role to assign</param>
        /// <returns>No content if successful</returns>
        [HttpPost("{userId:guid}/roles")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignRole(Guid userId, [FromBody] AssignRoleRequest request)
        {
            var command = new AssignRoleToUserCommand
            {
                UserId = userId,
                RoleId = request.RoleId
            };

            var success = await _mediator.Send(command);
            if (!success)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Authenticates a user and returns a token.
        /// </summary>
        /// <param name="command">The login credentials.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == "Invalid username or password")
            {
                return Unauthorized(result);
            }
            return Ok(new { Token = result });
        }
    }
}
