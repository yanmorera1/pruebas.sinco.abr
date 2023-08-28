using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.PatchTeacher
{
    public class PatchTeacherCommand : IRequest<TeacherVm>
    {
        public int TeacherId { get; set; }
        public JsonPatchDocument TeacherDocument { get; set; }

        public PatchTeacherCommand(int teacherId, JsonPatchDocument teacherDocument)
        {
            TeacherId = teacherId;
            TeacherDocument = teacherDocument;
        }
        public PatchTeacherCommand()
        {

        }
    }
}
