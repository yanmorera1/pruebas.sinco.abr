using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Students.Commands.AddStudent
{
    public class AddStudentComandHandler : IRequestHandler<AddStudentComand, StudentVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddStudentComandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentVm> Handle(AddStudentComand request, CancellationToken cancellationToken)
        {
            var newStudent = new Student(
                request.IdentificationNumber,
                request.Name,
                request.LastName,
                request.Age,
                request.Address,
                request.PhoneNumber);
            await _unitOfWork.Repository<Student>().AddAsync(newStudent);
            return _mapper.Map<StudentVm>(newStudent);
        }
    }
}
