using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Validations
{
    public class StudentValidations
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentValidations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> StudentExists(int id)
            => await _unitOfWork.Repository<Student>().AnyAsync(m => m.Id == id);
    }
}
