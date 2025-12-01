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

        public async Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma)
        {
            return await _context.Matriculas
                .Where(m => m.Id_turma == idTurma)
                .ToListAsync();
        }

        

    }
    /*
     * public async Task<Matricula?> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Turma)
                .ThenInclude(t => t.Curso)
                .Include(m => m.Alunos)
                .Include(m => m.Pagamentos)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
     */

}
