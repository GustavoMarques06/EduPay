using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPay.Infrastructure.Repository
{
    public class EduPayGenericRepository<T> : IEduPayGenericRepository<T> where T : class
    {
        protected readonly EduPayContext _context;
        protected readonly DbSet<T> _dbSet;

        public EduPayGenericRepository(EduPayContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // vai simplificar pois ao inves de chamar  "_context.Set<T>().FindAsync(id)"  chama "_dbSet.FindAsync(id)"
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<T> PostAsync(T entity)
        {
            _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var GenericClass = await GetByIdAsync(id);
            if (GenericClass != null)
            {
                _dbSet.Remove(GenericClass);
                await _context.SaveChangesAsync();
            }
        }

    }
}
