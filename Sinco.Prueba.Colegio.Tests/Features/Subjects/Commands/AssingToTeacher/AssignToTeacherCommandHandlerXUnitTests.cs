using AutoFixture;
using AutoMapper;
using Moq;
using Shouldly;
using Sinco.Prueba.Colegio.Application.Exceptions;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AssingToTeacher;
using Sinco.Prueba.Colegio.Application.Mappings;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Repositories;
using Sinco.Prueba.Colegio.Tests.Moks;
using Xunit;

namespace Sinco.Prueba.Colegio.Tests.Features.Subjects.Commands.AssingToTeacher
{
    public class AssingToTeacherCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly ColegioDbContext _context;
        private readonly IMapper _mapper;

        public AssingToTeacherCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            _context = _unitOfWork.Object.ColegioDbContext;
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task AssingToTeacherResponseShouldBeOfTypeSubjectVm()
        {
            SetFixtures();
            var handler = new AssingToTeacherCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AssingToTeacherCommand(1, 1);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<SubjectVm>();
        }

        [Fact]
        public async Task AssingToTeacherResponseShouldBeAnNotFoundException()
        {
            var handler = new AssingToTeacherCommandHandler(_unitOfWork.Object, _mapper);
            var request = new AssingToTeacherCommand(1, 1);
            Should.Throw<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));
        }

        private void SetFixtures()
        {
            MockEntityRepository.CreateFixture<Teacher>()
                .With(t => t.Id, 1)
                .Create()
                .SaveIntoDb<Teacher, ColegioDbContext>(_context);
            MockEntityRepository.CreateFixture<Subject>()
                .With(c => c.Id, 1)
                .Create()
                .SaveIntoDb<Subject, ColegioDbContext>(_context);
        }
    }
}
