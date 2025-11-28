using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface ITurmaService : IEduPayGenericService<Turma>
    {
        Task<Turma> GetByNameAsync(string nome);
        Task<Turma> UpdateAsync(int id, Turma turma);
    }
}
