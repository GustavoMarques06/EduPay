using EduPay.Domain.Entities;
using EduPay.DTO;

namespace EduPay.Application.Interface
{
    public interface ICursoService : IEduPayGenericService<Curso>
    {
        Task<Curso> GetByNameAsync(string nome);
        Task<Curso> UpdateAsync(int id, CursoUpdateDto dto);

        Task<IEnumerable<Turma>> GetTurmasByCursoAsync(int id_curso);
        //Task<Curso> GetCursoByTurmaAsync(int idTurma);

    }
}
