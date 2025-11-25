using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface ITurmaRepository : IEduPayGenericRepository<Turma>
    {
        Task<Turma> GetByNameAsync(string nome);
        new Task<IEnumerable<Turma>> GetAllAsync();
    }
}
