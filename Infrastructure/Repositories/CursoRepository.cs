using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Repositories
{
    public class CursoRepository : EduPayGenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(EduPayContext context) : base(context)
        {
        }

        public async Task<Curso> GetByNameAsync(string nome)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
        }
    }
}
