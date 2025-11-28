using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;

namespace EduPay.Application.Service
{
    public class EduPayGenericService<T> : IEduPayGenericService<T> where T : class
    {
        private readonly IEduPayGenericRepository<T> _repo;

        public EduPayGenericService(IEduPayGenericService<T> repo) 
        { 
            _repo = repo;
        }

        public async Task<T> CreateAsync(T entity)
        {
            return await _repo.PostAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
