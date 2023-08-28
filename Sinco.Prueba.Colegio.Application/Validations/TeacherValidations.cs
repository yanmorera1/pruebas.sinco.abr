using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Validations
{
    public class TeacherValidations
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherValidations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> TeacherExists(int id)
            => await _unitOfWork.Repository<Teacher>().AnyAsync(m => m.Id == id);
    }
}
