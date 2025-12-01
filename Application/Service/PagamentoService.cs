using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repositories;

namespace EduPay.Application.Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _repo;

        public PagamentoService(IPagamentoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Pagamento>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Pagamento?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Pagamento?> GetByCodAsync(Guid cod)
        {
            return await _repo.GetByCodAsync(cod);
        }

        public async Task<List<Pagamento>> GetByMatriculaAsync(int idMatricula)
        {
            return await _repo.GetByMatriculaAsync(idMatricula);
        }

        public async Task<double> GetTotalPagoPorAlunoAsync(int alunoId)
        {
            return await _repo.GetTotalPagoPorAlunoAsync(alunoId);
        }
            

        public async Task<double> GetTotalPagoPorMatriculaAsync(int matriculaId)
        {
            return await _repo.GetTotalPagoPorMatriculaAsync(matriculaId);
        }

        public async Task<IEnumerable<Pagamento>> GetPagamentosPorPeriodoAsync(DateOnly inicio, DateOnly fim)
        {
            return await _repo.GetPagamentosPorPeriodoAsync(inicio, fim);
        }
            

        public async Task<IEnumerable<Pagamento>> FiltrarPagamentosPorValorAsync(double? min, double? max)
        {
            return await _repo.FiltrarPagamentosPorValorAsync(min, max);
        }
            


        public async Task<Pagamento> CreateAsync(Pagamento pagamento)
        {
            // Segurança: evitar que o EF tente criar entidades aninhadas
            pagamento.Aluno = null;
            pagamento.Matricula = null;

            return await _repo.PostAsync(pagamento);
        }

        public async Task<Pagamento> UpdateAsync(int id, Pagamento pagamento)
        {
            var existe = await _repo.GetByIdAsync(id);
            if (existe == null)
                return null;


            existe.Cod_transacao = pagamento.Cod_transacao;
            existe.Data_pagamento = pagamento.Data_pagamento;

            return await _repo.UpdateAsync(existe);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
