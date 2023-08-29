using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Application.Specifications.Subjects;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Queries.GetSubject
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, IReadOnlyList<SubjectVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSubjectQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SubjectVm>> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            var spec = new SubjectSpecification(request.SubjectId, true);
            var subjects = await _unitOfWork.Repository<Subject>().GetAllWithSpec(spec);
            return _mapper.Map<IReadOnlyList<SubjectVm>>(subjects);
        }
    }
}
