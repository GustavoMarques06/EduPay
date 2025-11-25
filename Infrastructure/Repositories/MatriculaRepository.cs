using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Repositories
{
    public class MatriculaRepository : EduPayGenericRepository<Matricula>,IMatriculaRepository
    {
        public MatriculaRepository(EduPayContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Matricula>> GetAllAsync()
        {
            return await _dbSet
                .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)   // opcional
                .ToListAsync();
        }

        // Sobrescreve o GetById do generic
        public override async Task<Matricula?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // Continua com o método extra da interface
        public async Task<Matricula?> GetByDataAsync(DateOnly Data)
        {
            return await _dbSet
                .Include(m => m.Turma)  // Inclua aqui também
                .FirstOrDefaultAsync(x => x.data_matricula == Data);
        }
    }


}
