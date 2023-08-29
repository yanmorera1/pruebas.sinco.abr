using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<IReadOnlyList<StudentVm>>
    {
        public int? StudentId { get; set; }
    }
}
