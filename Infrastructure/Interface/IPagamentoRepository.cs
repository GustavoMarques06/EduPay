using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface IPagamentoRepository : IEduPayGenericRepository<Pagamento>
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<Pagamento> GetByCodAsync(string nome);
    }
}
