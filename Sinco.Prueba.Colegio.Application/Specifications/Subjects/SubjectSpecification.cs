using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Specifications.Subjects
{
    public class SubjectSpecification : Specification<Subject>
    {
        public SubjectSpecification(int? subjectId, bool isActive) : 
            base(s =>
            (!subjectId.HasValue || s.Id == subjectId) &&
            (s.IsActive == isActive))
        {
            AddInclude(s => s.Teacher);
        }
    }   
}
