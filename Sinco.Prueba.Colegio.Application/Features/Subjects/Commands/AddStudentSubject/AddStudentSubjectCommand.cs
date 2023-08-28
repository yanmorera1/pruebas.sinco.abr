using MediatR;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddStudentSubject
{
    public class AddStudentSubjectCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public float Rating { get; set; }

        public AddStudentSubjectCommand(int studentId, int subjectId, float rating)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            Rating = rating;
        }

        public AddStudentSubjectCommand()
        {
            
        }
    }
}
