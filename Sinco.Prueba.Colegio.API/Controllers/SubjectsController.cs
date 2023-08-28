using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddSubject;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubjectsReport;

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
        public async Task<ActionResult> GetReport(GetSubjectsReportQuery query)
            => Ok(await _mediator.Send(query));
    }
}
