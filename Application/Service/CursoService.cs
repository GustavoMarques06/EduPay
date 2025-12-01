using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;

namespace EduPay.Application.Service
{
    public class CursoService : EduPayGenericService<Curso>, ICursoService
    {
        private readonly ICursoRepository _repo;

            public CursoService(ICursoRepository repo)
                : base(repo)  // <- envia para o service genérico
            {
                _repo = repo;
            }

            public async Task<Curso> GetByNameAsync(string nome)
            {
                return await _repo.GetByNameAsync(nome);
            }

            public async Task<IEnumerable<Turma>> GetTurmasByCursoAsync(int id_curso)
            {
               return await _repo.GetTurmasByCursoAsync(id_curso);
            }

        public async Task<Curso> UpdateAsync(int id, Curso curso)
            {
                var existe = await _repo.GetByIdAsync(id);

                if (existe == null)
                    return null;

                existe.Nome = curso.Nome;
                existe.CargaHoraria = curso.CargaHoraria;

                return await _repo.UpdateAsync(existe);
            }
    }
}




