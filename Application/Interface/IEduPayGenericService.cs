using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IEduPayGenericService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
