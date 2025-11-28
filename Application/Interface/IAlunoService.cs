using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IAlunoService : IEduPayGenericService<Aluno>
    {
        Task<Aluno> GetByNameAsync(string nome);
        Task<Aluno> UpdateAsync(int id, Aluno aluno);
    }
}
