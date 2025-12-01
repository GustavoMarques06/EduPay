using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Repositories
{
    public class PagamentoRepository: EduPayGenericRepository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(EduPayContext context) : base(context) 
        {
            
        }

        public override async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Aluno)
                .Include(p => p.Matricula)
                .ThenInclude(m => m.Turma)
                .ToListAsync();
        }

        // GET BY ID com INCLUDES
        public override async Task<Pagamento?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Aluno)
                .Include(p => p.Matricula)
                .ThenInclude(m => m.Turma)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Caso você queira buscar por data (exemplo)
        public async Task<Pagamento?> GetByCodAsync(string cod)
        {
            return await _dbSet
                .Include(p => p.Aluno)
                .Include(p => p.Matricula)
                .FirstOrDefaultAsync(p => p.Cod_transacao == cod);
        }

        public async Task<IEnumerable<Pagamento>> GetByAlunoAsync(int id_aluno)
        {
            return await _dbSet
                .Include(p => p.Aluno)
                .Include(p => p.Matricula)
                    .ThenInclude(m => m.Turma)
                .Where(p => p.Id_aluno == id_aluno)
                .ToListAsync();
        }

        public async Task<List<Pagamento>> GetByMatriculaAsync(int idMatricula)
        {
            return await _context.Pagamentos
                .Where(p => p.Id_matricula == idMatricula)
                .ToListAsync();
        }

        public async Task<double> GetTotalPagoPorAlunoAsync(int alunoId)
        {
            return await _context.Pagamentos
                .Where(p => p.Id_aluno == alunoId)
                .SumAsync(p => p.Valor);
        }

        public async Task<double> GetTotalPagoPorMatriculaAsync(int matriculaId)
        {
            return await _context.Pagamentos
                .Where(p => p.Id_matricula == matriculaId)
                .SumAsync(p => p.Valor);
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentosPorPeriodoAsync(DateOnly inicio, DateOnly fim)
        {
            return await _context.Pagamentos
                .Where(p => p.Data_pagamento >= inicio && p.Data_pagamento <= fim)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pagamento>> FiltrarPagamentosPorValorAsync(double? min, double? max)
        {
            var query = _context.Pagamentos.AsQueryable();

            if (min.HasValue)
                query = query.Where(p => p.Valor >= min.Value);

            if (max.HasValue)
                query = query.Where(p => p.Valor <= max.Value);

            return await query.ToListAsync();
        }

    }
}
