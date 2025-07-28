using MainProject.Application.Features.Postings.Commands.CreatePosting;
using MainProject.Application.Features.Postings.Commands.DeletePosting;
using MainProject.Application.Features.Postings.Commands.UpdatePosting;
using MainProject.Application.Features.Postings.Queries.GetAllPostings;
using MainProject.Application.Features.Postings.Queries.GetPostingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MainProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostingsController : ControllerBase
    {
        private readonly ISender _mediator;

        public PostingsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostingCommand command)
        {
            var postingId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = postingId }, postingId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetPostingByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPostingsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePostingCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePostingCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}