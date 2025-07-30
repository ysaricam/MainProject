using MainProject.Application.Features.EducationLevels.Commands.CreateEducationLevel;
using MainProject.Application.Features.EducationLevels.Commands.DeleteEducationLevel;
using MainProject.Application.Features.EducationLevels.Commands.UpdateEducationLevel;
using MainProject.Application.Features.EducationLevels.Queries.GetAllEducationLevels;
using MainProject.Application.Features.EducationLevels.Queries.GetEducationLevelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MainProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationLevelsController : ControllerBase
    {
        private readonly ISender _mediator;

        public EducationLevelsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEducationLevelCommand command)
        {
            var educationLevelId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = educationLevelId }, educationLevelId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetEducationLevelByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEducationLevelsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEducationLevelCommand command)
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
            var command = new DeleteEducationLevelCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}