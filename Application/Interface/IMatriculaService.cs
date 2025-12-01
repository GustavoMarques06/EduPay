using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IMatriculaService : IEduPayGenericService<Matricula>
    {
        Task<Matricula> GetByDataAsync(DateOnly Data);
        Task<Matricula> UpdateAsync(int id, Matricula matricula);

        Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma);
    }
}
