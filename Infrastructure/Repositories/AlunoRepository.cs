using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


namespace EduPay.Infrastructure.Repositories
{
    public class AlunoRepository : EduPayGenericRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EduPayContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.Matricula).ToListAsync();
        }

        // Sobrescreve o GetById do generic
        public override async Task<Aluno?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Matricula)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Continua com o método extra da interface
        public async Task<Aluno?> GetByNameAsync(string nome)
        {
            return await _dbSet
                .Include(a => a.Matricula)  // Inclua aqui também
                .FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
        }

        public async Task<Matricula?> GetMatriculaByAlunoAsync(int alunoId)
        {
            return await _context.Matriculas
                .FirstOrDefaultAsync(m => m.Id ==
                    _context.Alunos
                        .Where(a => a.Id == alunoId)
                        .Select(a => a.Id_matricula)
                        .FirstOrDefault()
                );
        }
    }
}
