using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Domain;

namespace Sinco.Prueba.Colegio.Application.Validations
{
    public class SubjectValidations
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectValidations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> SubjectExists(int id)
            => await _unitOfWork.Repository<Subject>().AnyAsync(m => m.Id == id);
    }
}
