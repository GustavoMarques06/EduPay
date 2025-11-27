using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;

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

        public async Task<Pagamento?> GetByCodAsync(string cod)
        {
            return await _repo.GetByCodAsync(cod);
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
