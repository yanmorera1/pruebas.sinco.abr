using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Application.Specifications.Students;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IReadOnlyList<StudentVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StudentVm>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var spec = new StudentSpecification(request.StudentId);
            var students = await _unitOfWork.Repository<Student>().GetAllWithSpec(spec);
            return _mapper.Map<IReadOnlyList<StudentVm>>(students);
        }
    }
}
