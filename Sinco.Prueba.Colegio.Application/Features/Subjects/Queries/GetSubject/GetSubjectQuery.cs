using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubject
{
    public class GetSubjectQuery : IRequest<IReadOnlyList<SubjectVm>>
    {
        public int? SubjectId { get; set; }
    }
}
