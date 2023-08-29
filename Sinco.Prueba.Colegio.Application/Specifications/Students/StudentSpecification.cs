using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Specifications.Students
{
    public class StudentSpecification : Specification<Student>
    {
        public StudentSpecification(int? studentId, bool isActive) : 
            base(s =>
            (!studentId.HasValue || s.Id == studentId) &&
            (s.IsActive == isActive))
        {
            AddInclude(s => s.StudentSubjects);
        }
    }
}
