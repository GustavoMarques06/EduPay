using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;

namespace EduPay.Application.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repo;

        public AlunoService(IAlunoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Aluno> GetByNameAsync(string nome)
        {
            return await _repo.GetByNameAsync(nome);
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            return await _repo.PostAsync(aluno);
        }
        public async Task<Aluno> UpdateAsync(int id, Aluno aluno)
        {
            var existe = await _repo.GetByIdAsync(id);
            if (existe == null)
                return null;

            existe.Nome = aluno.Nome;
            existe.Data_nascimento = aluno.Data_nascimento;

            return await _repo.UpdateAsync(existe);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
