using MediatR;
using Sinco.Prueba.Colegio.Application.Models.ViewModels;

namespace Sinco.Prueba.Colegio.Application.Features.Teachers.Commands.AddTeacher
{
    public class AddTeacherCommand : IRequest<TeacherVm>
    {
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
