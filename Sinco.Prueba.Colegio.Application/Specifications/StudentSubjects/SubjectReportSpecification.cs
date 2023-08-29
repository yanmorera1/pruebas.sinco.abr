using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Specifications.StudentSubjects
{
    public class SubjectReportSpecification : Specification<StudentSubject>
    {
        public SubjectReportSpecification(int year) : base(
            ss => ss.CreatedAt.Value.Year == year)
        {
            AddInclude(ss => ss.Subject);
            AddInclude(ss => ss.Student);
            AddInclude($"{nameof(StudentSubject.Subject)}.{nameof(Subject.Teacher)}");
        }
    }
}
