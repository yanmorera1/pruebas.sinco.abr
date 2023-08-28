using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Queries.GetTeachers
{
    public class GetTeachersQuery : IRequest<IReadOnlyList<TeacherVm>>
    {

    }
}
