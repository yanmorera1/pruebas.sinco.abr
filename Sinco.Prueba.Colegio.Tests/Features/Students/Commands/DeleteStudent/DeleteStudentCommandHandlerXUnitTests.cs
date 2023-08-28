using AutoFixture;
using AutoMapper;
using Moq;
using Shouldly;
using Sinco.Prueba.Colegio.Application.Exceptions;
using Sinco.Prueba.Colegio.Application.Features.Students.Commands.DeleteStudent;
using Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AssingToTeacher;
using Sinco.Prueba.Colegio.Application.Mappings;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;
using Sinco.Prueba.Colegio.Domain;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Repositories;
using Sinco.Prueba.Colegio.Tests.Moks;
using Xunit;

namespace Sinco.Prueba.Colegio.Tests.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly ColegioDbContext _context;
        public DeleteStudentCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            _context = _unitOfWork.Object.ColegioDbContext;
        }

        [Fact]
        public async Task DeleteStudentResponseShouldBeThrowBadRequestException()
        {
            //Estudiante con materias
            MockEntityRepository.CreateFixture<Student>()
                .With(t => t.Id, 1)
                .Create()
                .SaveIntoDb<Student, ColegioDbContext>(_context);

            var handler = new DeleteStudentCommandHandler(_unitOfWork.Object);
            var request = new DeleteStudentCommand(1);
            Should.Throw<BadRequestException>(async () => await handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteStudentResponseShouldBeOfTypeBool()
        {
            //Estudiante sin materias
            MockEntityRepository.CreateFixture<Student>()
                .With(s => s.Id, 1)
                .Without(s => s.StudentSubjects)
                .Create()
                .SaveIntoDb<Student, ColegioDbContext>(_context);

            var handler = new DeleteStudentCommandHandler(_unitOfWork.Object);
            var request = new DeleteStudentCommand(1);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<bool>();
        }
    }
}
