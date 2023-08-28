using Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubjectsReport;
using Sinco.Prueba.Colegio.Domain;
using System.Linq.Expressions;

namespace Sinco.Prueba.Colegio.Application.Specifications.Subjects
{
    public class SubjectReportSpecification : Specification<StudentSubject>
    {
        public SubjectReportSpecification(GetSubjectsReportQuery query) : base()
        {
            AddInclude(ss => ss.Subject);
            AddInclude(ss => ss.Student);
            AddInclude($"{nameof(StudentSubject.Subject)}.{nameof(Subject.Teacher)}");
        }
    }
}
