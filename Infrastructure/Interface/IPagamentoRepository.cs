using EduPay.Domain.Entities;

namespace EduPay.Infrastructure.Interface
{
    public interface IPagamentoRepository : IEduPayGenericRepository<Pagamento>
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        //Task<List<Pagamento>> GetByAlunoAsync(int idAluno);

        Task<List<Pagamento>> GetByMatriculaAsync(int idMatricula);
        Task<Pagamento> GetByCodAsync(Guid nome);

        //Operações Financeiras - Total, intervalo entre datas ou valores
        Task<double> GetTotalPagoPorAlunoAsync(int alunoId);
        Task<double> GetTotalPagoPorMatriculaAsync(int matriculaId);
        Task<IEnumerable<Pagamento>> GetPagamentosPorPeriodoAsync(DateOnly inicio, DateOnly fim);
        Task<IEnumerable<Pagamento>> FiltrarPagamentosPorValorAsync(double? min, double? max);
    }
}
