using MediatR;
using Microsoft.AspNetCore.Mvc;
using MainProject.Application.Features.Branches.Commands.CreateBranch;
using MainProject.Application.Features.Branches.Queries.GetBranchById;
using System;
using System.Threading.Tasks;

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

            var branchId = await _mediator.Send(command);


            return CreatedAtAction(nameof(GetById), new { id = branchId }, branchId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetBranchByIdQuery { Id = id };
            var result = await _mediator.Send(query);


            return Ok(result);
        }
    }
}