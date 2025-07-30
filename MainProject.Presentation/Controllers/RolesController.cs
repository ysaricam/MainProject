using MainProject.Application.Features.Roles.Commands.CreateRole;
using MainProject.Application.Features.Roles.Commands.DeleteRole;
using MainProject.Application.Features.Roles.Commands.UpdateRole;
using MainProject.Application.Features.Roles.Queries.GetAllRoles;
using MainProject.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MainProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ISender _mediator;

        public RolesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RoleDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery { Id = id });
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoleCommand command)
        {
            var roleId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = roleId }, roleId);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                command.Id = id;
            }

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteRoleCommand(id));
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}