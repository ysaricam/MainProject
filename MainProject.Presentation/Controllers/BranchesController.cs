using MediatR;
using Microsoft.AspNetCore.Mvc;
using MainProject.Application.Features.Branches.Commands.CreateBranch;
using MainProject.Application.Features.Branches.Queries.GetAllBranches;
using MainProject.Application.Features.Branches.Commands.UpdateBranch;
using MainProject.Application.Features.Branches.Commands.DeleteBranch;
using MainProject.Application.Features.Branches.Queries.GetBranchById;
using MainProject.Application.Features.Branches.Dtos;

namespace MainProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : ControllerBase
    {

        private readonly ISender _mediator;


        public BranchesController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(null, new { id = result }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBranchesQuery();
            var result = await _mediator.Send(query);
            return Ok(result); 
        }

        /// <summary>
        /// Gets a branch by ID
        /// </summary>
        /// <param name="id">The ID of the branch to retrieve</param>
        /// <returns>The branch details</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BranchDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetBranchByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBranchRequest request)
        {
            var command = new UpdateBranchCommand
            {
                Id = id,
                Name = request.Name,
                Description = request.Description
            };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBranchCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }


    public record UpdateBranchRequest(string Name, string Description);
}