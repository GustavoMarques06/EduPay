using AutoMapper;
using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.DTO;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repository;
using NuGet.Protocol.Core.Types;

namespace EduPay.Application.Service
{
    public class CursoService : EduPayGenericService<Curso>, ICursoService
    {
        private readonly ICursoRepository _repo;
        private readonly IMapper _mapper;

            public CursoService(ICursoRepository repo, IMapper mapper)
                : base(repo)  // <- envia para o service genérico
            {
                _repo = repo;
                _mapper = mapper;
            }

            public async Task<Curso> GetByNameAsync(string nome)
            {
                return await _repo.GetByNameAsync(nome);
            }

            public async Task<IEnumerable<Turma>> GetTurmasByCursoAsync(int id_curso)
            {
               return await _repo.GetTurmasByCursoAsync(id_curso);
            }

        public async Task<Curso> UpdateAsync(int id, CursoUpdateDto dto)
        {
            var existente = await _repo.GetByIdAsync(id);
            if (existente == null)
                return null;

            if (existente.CursoTipo != dto.CursoTipo)
                throw new InvalidOperationException("Não é permitido mudar o tipo do curso.");

            _mapper.Map(dto, existente);
            await _repo.UpdateAsync(existente);

            return existente;
        }

    }
}




