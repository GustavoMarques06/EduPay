using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface ICursoRepository : IEduPayGenericRepository<Curso>
    {
        Task<Curso> GetByNameAsync(string nome);
    }
}
