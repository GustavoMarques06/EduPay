using EduPay.Application.Interface;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;


namespace EduPay.Application.Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _repo;

        public MatriculaService(IMatriculaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Matricula>> GetAllAsync()
        {
            return (await _repo.GetAllAsync()).ToList();
        }

        public async Task<Matricula> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Matricula> GetByDataAsync(DateOnly Data)
        {
            return await _repo.GetByDataAsync(Data);
        }

        public async Task<Matricula> CreateAsync(Matricula matricula)
        {
            return await _repo.PostAsync(matricula);
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

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
