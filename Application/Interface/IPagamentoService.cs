using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IPagamentoService : IEduPayGenericService<Pagamento>
    {
        Task<Pagamento> GetByCodAsync(string cod);
        Task<Pagamento> UpdateAsync(int id, Pagamento pagamento);
    }
}
