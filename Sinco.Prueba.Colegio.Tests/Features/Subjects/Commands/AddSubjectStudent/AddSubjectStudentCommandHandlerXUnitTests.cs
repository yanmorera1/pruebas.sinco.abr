using AutoFixture;
using Moq;
using Shouldly;
using Sinco.Prueba.Colegio.Application.Exceptions;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddStudentSubject;
using Sinco.Prueba.Colegio.Domain;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Repositories;
using Sinco.Prueba.Colegio.Tests.Moks;
using Xunit;

namespace Sinco.Prueba.Colegio.Tests.Features.Subjects.Commands.AddSubjectStudent
{
    public class AddSubjectStudentCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly ColegioDbContext _context;

        public AddSubjectStudentCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            _context = _unitOfWork.Object.ColegioDbContext;
        }

        [Fact]
        public async Task AddStudentSubjectResponseShouldBeOfTypeInt()
        {
            SetFixtures();
            var handler = new AddStudentSubjectCommandHandler(_unitOfWork.Object);
            var request = new AddStudentSubjectCommand(1, 1, 2.9f);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<int>();
        }

        [Fact]
        public async Task AddStudentSubjectResponseShouldThrowBadRequestException()
        {
            SetFixtures();
            var handler = new AddStudentSubjectCommandHandler(_unitOfWork.Object);
            var request1 = new AddStudentSubjectCommand(1, 1, 2.9f);
            await handler.Handle(request1, CancellationToken.None);

            var request2 = new AddStudentSubjectCommand(1, 1, 4.9f);
            Should.Throw<BadRequestException>(async () => await handler.Handle(request2, CancellationToken.None));
        }

        private void SetFixtures()
        {
            MockEntityRepository.CreateFixture<Student>()
                .With(t => t.Id, 1)
                .Create()
                .SaveIntoDb<Student, ColegioDbContext>(_context);
            MockEntityRepository.CreateFixture<Subject>()
                .With(c => c.Id, 1)
                .Create()
                .SaveIntoDb<Subject, ColegioDbContext>(_context);
        }
    }
}
