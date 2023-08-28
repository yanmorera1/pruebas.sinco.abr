using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AssingToTeacher
{
    public class AssingToTeacherCommand : IRequest<SubjectVm>
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public AssingToTeacherCommand(int teacherId, int subjectId)
        {
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
        public AssingToTeacherCommand()
        {
            
        }
    }
}
