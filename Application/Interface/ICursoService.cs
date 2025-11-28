using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface ICursoService : IEduPayGenericService<Curso>
    {
        Task<Curso> GetByNameAsync(string nome);
        Task<Curso> UpdateAsync(int id, Curso curso);
    }
}
