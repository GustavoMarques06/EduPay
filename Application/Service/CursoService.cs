using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;

namespace EduPay.Application.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repo;

        public CursoService(ICursoRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Curso>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Curso> GetByNameAsync(string nome)
        {
            return await _repo.GetByNameAsync(nome);
        }

        public async Task<Curso> CreateAsync(Curso curso)
        {
            return await _repo.PostAsync(curso);
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

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }


    }
}
