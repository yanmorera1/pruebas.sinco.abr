using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Application.Specifications.Teachers;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Queries.GetTeachers
{
    public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, IReadOnlyList<TeacherVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTeachersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TeacherVm>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            var spec = new TeacherSpecification(request.TeacherId, true);
            var teachers = await _unitOfWork.Repository<Teacher>().GetAllWithSpec(spec);
            return _mapper.Map<IReadOnlyList<TeacherVm>>(teachers);
        }
    }
}
