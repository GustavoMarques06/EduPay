using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;


namespace EduPay.Application.Service
{
    public class TurmaService : EduPayGenericService<Turma>, ITurmaService
    {
        private readonly ITurmaRepository _repo;

        public TurmaService(ITurmaRepository repo)
        : base(repo)  // <- envia para o service genérico
        {
            _repo = repo;
        }
        

        public async Task<Turma> GetByNameAsync(string nome)
        {
            return await _repo.GetByNameAsync(nome);
        }

        public async Task<Turma> UpdateAsync(int id, Turma turma)
        {
            var existe = await _repo.GetByIdAsync(id);
            if (existe == null)
                return null;

            existe.Nome = turma.Nome;
            existe.Periodo = turma.Periodo;

            return await _repo.UpdateAsync(existe);
        }

        public async Task<IEnumerable<Matricula>> GetMatriculasByTurmaAsync(int turmaId)
        {
            return await _repo.GetMatriculasByTurmaAsync(turmaId);
        }

        public async Task<Curso?> GetCursoByTurmaAsync(int idTurma)
        {
            return await _repo.GetCursoByTurmaAsync(idTurma);
        }
    }
}
