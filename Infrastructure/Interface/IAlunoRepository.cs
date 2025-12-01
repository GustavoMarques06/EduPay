using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface IAlunoRepository : IEduPayGenericRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno> GetByNameAsync(string nome);

        Task<Matricula?> GetMatriculaByAlunoAsync(int alunoId);
    }
}
