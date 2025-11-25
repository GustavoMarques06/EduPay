using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface IMatriculaRepository : IEduPayGenericRepository<Matricula>
    {
        Task<IEnumerable<Matricula>> GetAllAsync();

        Task<Matricula> GetByDataAsync(DateOnly Data);

    }
}
