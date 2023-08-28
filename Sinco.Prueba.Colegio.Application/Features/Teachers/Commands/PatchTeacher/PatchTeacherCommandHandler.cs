using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.PatchTeacher
{
    public class PatchTeacherCommandHandler : IRequestHandler<PatchTeacherCommand, TeacherVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatchTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeacherVm> Handle(PatchTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherUpdated = await _unitOfWork.Repository<Teacher>().PatchAync(request.TeacherId, request.TeacherDocument);
            return _mapper.Map<TeacherVm>(teacherUpdated);
        }
    }
}
