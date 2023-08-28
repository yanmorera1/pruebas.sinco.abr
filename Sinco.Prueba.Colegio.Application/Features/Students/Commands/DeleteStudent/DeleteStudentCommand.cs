using MediatR;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }

        public DeleteStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
        public DeleteStudentCommand()
        {
            
        }
    }
}
