using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.PatchStudent
{
    public class PatchStudentCommand : IRequest<StudentVm>
    {
        public int StudentId { get; set; }
        public JsonPatchDocument StudentPatch { get; set; }

        public PatchStudentCommand(int studentId, JsonPatchDocument studentPatch)
        {
            StudentId = studentId;
            StudentPatch = studentPatch;
        }
        public PatchStudentCommand()
        {
            
        }
    }
}
