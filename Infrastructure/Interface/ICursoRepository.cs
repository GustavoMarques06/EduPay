using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface ICursoRepository : IEduPayGenericRepository<Curso>
    {
        Task<IEnumerable<Turma>> GetTurmasByCursoAsync(int id_curso);
        Task<Curso> GetByNameAsync(string nome);
    }
}
