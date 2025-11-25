using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAllAsync();
        Task<Aluno> GetByIdAsync(int id);
        Task<Aluno> GetByNameAsync(string nome);
        Task<Aluno> CreateAsync(Aluno aluno);
        Task<Aluno> UpdateAsync(int id, Aluno aluno);
        Task DeleteAsync(int id);
    }
}
