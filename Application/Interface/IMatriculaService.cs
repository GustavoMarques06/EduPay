using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IMatriculaService
    {
        Task<List<Matricula>> GetAllAsync();
        Task<Matricula> GetByIdAsync(int id);

        Task<Matricula> GetByDataAsync(DateOnly Data);
        Task<Matricula> CreateAsync(Matricula matricula);
        Task<Matricula> UpdateAsync(int id, Matricula matricula);
        Task DeleteAsync(int id);
    }
}
