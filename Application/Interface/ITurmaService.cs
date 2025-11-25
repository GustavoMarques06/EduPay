using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface ITurmaService
    {
        Task<List<Turma>> GetAllAsync();
        Task<Turma> GetByIdAsync(int id);
        Task<Turma> GetByNameAsync(string nome);
        Task<Turma> CreateAsync(Turma turma);
        Task<Turma> UpdateAsync(int id, Turma turma);
        Task DeleteAsync(int id);
    }
}
