using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.AddTeacher
{
    public class AddTeacherCommandHandler : IRequestHandler<AddTeacherCommand, TeacherVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeacherVm> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            var newTeacher = new Teacher(
                request.IdentificationNumber, 
                request.Name, 
                request.LastName, 
                request.Age, 
                request.Address, 
                request.PhoneNumber);
            await _unitOfWork.Repository<Teacher>().AddAsync(newTeacher);
            return _mapper.Map<TeacherVm>(newTeacher);
        }
    }
}
