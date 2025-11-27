using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IPagamentoService
    {
        Task<List<Pagamento>> GetAllAsync();
        Task<Pagamento> GetByIdAsync(int id);
        Task<Pagamento> GetByCodAsync(string cod);
        Task<Pagamento  > CreateAsync(Pagamento pagamento);
        Task<Pagamento> UpdateAsync(int id, Pagamento pagamento);
        Task DeleteAsync(int id);
    }
}
