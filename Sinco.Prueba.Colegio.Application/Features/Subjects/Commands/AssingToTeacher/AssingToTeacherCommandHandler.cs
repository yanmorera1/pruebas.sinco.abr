using AutoMapper;
using MediatR;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Application.Exceptions;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AssingToTeacher
{
    public class AssingToTeacherCommandHandler : IRequestHandler<AssingToTeacherCommand, SubjectVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssingToTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectVm> Handle(AssingToTeacherCommand request, CancellationToken cancellationToken)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetFirstOrDefaultAsync(s => s.Id == request.SubjectId, s => s.Teacher);
            if (subject is null)
                throw new NotFoundException($"{typeof(Subject)} was not found");
            subject.TeacherId = request.TeacherId;
            await _unitOfWork.Complete();
            return _mapper.Map<SubjectVm>(subject);
        }
    }
}
