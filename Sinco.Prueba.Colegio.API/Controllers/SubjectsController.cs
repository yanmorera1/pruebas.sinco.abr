using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddSubject;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.UpdateSubject;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubject;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubjectsReport;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.API.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddSubject(AddSubjectCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SubjectVm>>> GetSubjects([FromQuery] GetSubjectQuery query)
            => Ok(await _mediator.Send(query));

        [HttpPatch]
        public async Task<ActionResult> AssingToTeacher([FromRoute] int subjectId, JsonPatchDocument jsonPatch)
            => Ok(await _mediator.Send(new UpdateSubjectCommand(subjectId, jsonPatch)));

        [HttpGet("report")]
        public async Task<ActionResult<IReadOnlyList<ReportVm>>> GetReport([FromQuery] GetSubjectsReportQuery query)
            => Ok(await _mediator.Send(query));

    }
}
