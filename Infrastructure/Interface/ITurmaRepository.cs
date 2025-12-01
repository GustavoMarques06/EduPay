using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface ITurmaRepository : IEduPayGenericRepository<Turma>
    {
        Task<Turma> GetByNameAsync(string nome);
        Task<IEnumerable<Turma>> GetAllAsync();

        Task<IEnumerable<Matricula>> GetMatriculasByTurmaAsync(int turmaId);

        Task<Curso?> GetCursoByTurmaAsync(int turmaId);

    }
}
