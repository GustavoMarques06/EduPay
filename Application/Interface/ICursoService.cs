using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface ICursoService
    {
        Task<List<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int id);
        Task<Curso> GetByNameAsync(string nome);
        Task<Curso> CreateAsync(Curso curso);
        Task<Curso> UpdateAsync(int id, Curso curso);
        Task DeleteAsync(int id);
    }
}
