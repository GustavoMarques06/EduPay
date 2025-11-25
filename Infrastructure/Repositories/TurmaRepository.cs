using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Repositories
{
    public class TurmaRepository : EduPayGenericRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EduPayContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Turma>> GetAllAsync()
        {
            return await _dbSet.Include(t => t.Curso).ToListAsync();
        }

        // Sobrescreve o GetById do generic
        public override async Task<Turma?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Curso)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        // Continua com o método extra da interface
        public async Task<Turma?> GetByNameAsync(string nome)
        {
            return await _dbSet
                .Include(t => t.Curso)  // Inclua aqui também
                .FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
        }

        /*public override async Task<IEnumerable<Turma>> GetAllAsync()
        {
            return await _dbSet
                .Include(t => t.curso)
                .ToListAsync();
        }*/

    }
}
