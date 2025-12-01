using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repositories;


namespace EduPay.Application.Service
{
    public class MatriculaService :  EduPayGenericService<Matricula>, IMatriculaService
    {

        private readonly IMatriculaRepository _repo;

        public MatriculaService(IMatriculaRepository repo)
                : base(repo)  // <- envia para o service genérico
        {
            _repo = repo;
            
        }

        public async Task<Matricula> GetByDataAsync(DateOnly Data)
        {
            return await _repo.GetByDataAsync(Data);
        }

        public async Task<IEnumerable<Matricula>> GetByTurmaAsync(int idTurma)
        {
            return await _repo.GetByTurmaAsync(idTurma);
        }

        public async Task<Matricula> UpdateAsync(int id, Matricula matricula)
        {
            var existe = await _repo.GetByIdAsync(id);
            if (existe == null)
                return null;

            existe.data_matricula = matricula.data_matricula;
            existe.status = matricula.status;

            return await _repo.UpdateAsync(existe);
        }

    }
}
