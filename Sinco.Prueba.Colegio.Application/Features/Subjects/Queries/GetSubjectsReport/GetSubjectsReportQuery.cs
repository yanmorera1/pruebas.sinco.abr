using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubjectsReport
{
    public class GetSubjectsReportQuery : IRequest<IReadOnlyList<ReportVm>>
    {

    }
}
