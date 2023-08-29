using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Specifications.Teachers
{
    public class TeacherSpecification : Specification<Teacher>
    {
        public TeacherSpecification(int? teacherId, bool isActive) : 
            base(t =>
            (!teacherId.HasValue || t.Id == teacherId) &&
            (t.IsActive == isActive))
        {
        }
    }
}
