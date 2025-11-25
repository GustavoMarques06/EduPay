using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;


namespace EduPay.Application.Service
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _repo;

        public TurmaService(ITurmaRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Turma>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Turma> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Turma> GetByNameAsync(string nome)
        {
            return await _repo.GetByNameAsync(nome);
        }

        public async Task<Turma> CreateAsync(Turma turma)
        {
            return await _repo.PostAsync(turma);
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

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
