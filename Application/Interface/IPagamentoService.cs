using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IPagamentoService : IEduPayGenericService<Pagamento>
    {
        Task<Pagamento> GetByCodAsync(string cod);
        Task<Pagamento> UpdateAsync(int id, Pagamento pagamento);

        //Task<Aluno> GetAlunoByPagamentoAsync(int idPagamento);

        Task<List<Pagamento>> GetByMatriculaAsync(int idMatricula);

        Task<double> GetTotalPagoPorAlunoAsync(int alunoId);
        Task<double> GetTotalPagoPorMatriculaAsync(int matriculaId);
        Task<IEnumerable<Pagamento>> GetPagamentosPorPeriodoAsync(DateOnly inicio, DateOnly fim);
        Task<IEnumerable<Pagamento>> FiltrarPagamentosPorValorAsync(double? min, double? max);
    }
}
