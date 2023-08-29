using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Application.Specifications.StudentSubjects;
using Sinco.Prueba.Colegio.Application.Specifications.Subjects;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubjectsReport
{
    public class GetSubjectsReportQueryHandler : IRequestHandler<GetSubjectsReportQuery, IReadOnlyList<ReportVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSubjectsReportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ReportVm>> Handle(GetSubjectsReportQuery request, CancellationToken cancellationToken)
        {
            var spec = new SubjectReportSpecification(request.Year);
            var report = await _unitOfWork.Repository<StudentSubject>().GetAllWithSpec(spec);
            return _mapper.Map<IReadOnlyList<ReportVm>>(report);
        }
    }
}
