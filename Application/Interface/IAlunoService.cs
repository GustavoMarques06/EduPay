using EduPay.Domain.Entities;

namespace EduPay.Application.Interface
{
    public interface IAlunoService : IEduPayGenericService<Aluno>
    {
        Task<Aluno> GetByNameAsync(string nome);
        Task<Aluno> UpdateAsync(int id, Aluno aluno);

        Task<Matricula?> GetMatriculaByAlunoAsync(int alunoId);

        //Task<List<Pagamento>> GetPagamentosByMatriculaAsync(int id_matricula);
    }
}
