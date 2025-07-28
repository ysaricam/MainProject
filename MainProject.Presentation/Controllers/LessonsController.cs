using MainProject.Application.Features.Lessons.Commands.CreateLesson;
using MainProject.Application.Features.Lessons.Commands.DeleteLesson;
using MainProject.Application.Features.Lessons.Commands.UpdateLesson;
using MainProject.Application.Features.Lessons.Queries.GetAllLessons;
using MainProject.Application.Features.Lessons.Queries.GetLessonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MainProject.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ISender _mediator;

        public LessonsController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonCommand command)
        {

            var lessonId = await _mediator.Send(command);


            return CreatedAtAction(nameof(GetById), new { id = lessonId }, lessonId);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetLessonByIdQuery { Id = id };
            var result = await _mediator.Send(query);


            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllLessonsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLessonCommand command)
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
            var command = new DeleteLessonCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}