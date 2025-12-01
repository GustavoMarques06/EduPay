using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface IMatriculaRepository : IEduPayGenericRepository<Matricula>
    {
        Task<IEnumerable<Matricula>> GetAllAsync();

        Task<Matricula> GetByDataAsync(DateOnly Data);

        Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma);
        //Task<Matricula?> GetWithDetailsAsync(int id);

    }
}
