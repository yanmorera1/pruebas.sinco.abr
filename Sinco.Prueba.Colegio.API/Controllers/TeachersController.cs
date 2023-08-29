using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.AddTeacher;
using Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.PatchTeacher;
using Sinco.Prueba.Colegio.Application.Features.Teachers.Queries.GetTeachers;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.API.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<TeacherVm>> AddTeacher([FromBody] AddTeacherCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TeacherVm>>> GetTeachers([FromQuery] GetTeachersQuery query)
            => Ok(await _mediator.Send(query));

        [HttpPatch("{teacherId}")]
        public async Task<ActionResult<TeacherVm>> PatchTeacher([FromRoute] int teacherId, JsonPatchDocument teacherDocument)
            => Ok(await _mediator.Send(new PatchTeacherCommand(teacherId, teacherDocument)));
    }
}
