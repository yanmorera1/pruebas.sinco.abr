using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest<SubjectVm>
    {
        public int SubjectId { get; set; }
        public JsonPatchDocument SubjetDocument { get; set; }

        public UpdateSubjectCommand(int subjectId, JsonPatchDocument subjetDocument)
        {
            SubjectId = subjectId;
            SubjetDocument = subjetDocument;
        }

        public UpdateSubjectCommand()
        {

        }
    }
}
