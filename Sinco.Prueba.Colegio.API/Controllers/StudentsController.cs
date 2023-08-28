using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sinco.Prueba.Colegio.Application.Features.Students.Commands.AddStudent;
using Sinco.Prueba.Colegio.Application.Features.Students.Commands.DeleteStudent;
using Sinco.Prueba.Colegio.Application.Features.Students.Commands.PatchStudent;
using Sinco.Prueba.Colegio.Application.Features.Students.Queries.GetStudents;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddStudentSubject;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<StudentVm>> AddStudent([FromBody] AddStudentComand comand)
            => Ok(await _mediator.Send(comand));

        [HttpPost("rating")]
        public async Task<ActionResult> AddStudentSubject(AddStudentSubjectCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StudentVm>>> GetStudents()
            => Ok(await _mediator.Send(new GetStudentsQuery()));

        [HttpPatch("{studentId}")]
        public async Task<ActionResult<StudentVm>> PatchStudent([FromRoute] int studentId, JsonPatchDocument studentDocument)
            => Ok(await _mediator.Send(new PatchStudentCommand(studentId, studentDocument)));

        [HttpDelete("{studentId}")]
        public async Task<ActionResult<bool>> DeleteStudent([FromRoute] int studentId)
            => Ok(await _mediator.Send(new DeleteStudentCommand(studentId)));
    }
}
