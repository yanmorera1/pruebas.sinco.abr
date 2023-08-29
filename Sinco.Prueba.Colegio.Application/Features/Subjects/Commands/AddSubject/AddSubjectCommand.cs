using MediatR;

namespace Sinco.Prueba.Colegio.Application.Features.Subjects.Commands.AddSubject
{
    public class AddSubjectCommand : IRequest<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
    }
}
