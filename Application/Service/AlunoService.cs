using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;

namespace EduPay.Application.Service
{
    public class AlunoService : EduPayGenericService<Aluno> ,IAlunoService
    {
        private readonly IAlunoRepository _repo;
        private readonly IMatriculaRepository _matriculaRepo;
        private readonly IPagamentoRepository _pagamentoRepo;

        public AlunoService(IAlunoRepository repo, IMatriculaRepository matriculaRepo, IPagamentoRepository pagamentoRepo)
        : base(repo)  // <- envia para o service genérico
        {
            _repo = repo;
            _matriculaRepo = matriculaRepo;
            _pagamentoRepo = pagamentoRepo;
        }

        public async Task<Aluno> GetByNameAsync(string nome)
        {
            return await _repo.GetByNameAsync(nome);
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

        public async Task<Matricula?> GetMatriculaByAlunoAsync(int alunoId)
        {
            return await _repo.GetMatriculaByAlunoAsync(alunoId);
        }

    }
}
