using EduPay.Application.Service;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduPay.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _service;

        public CursoController(CursoService service)
        {
            _service = service;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/cursos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cursoid = await _service.GetByIdAsync(id);
            if (cursoid == null)
            {
                return NotFound($"Curso com id: {id} não foi encontrado.");
            }
            return Ok(cursoid);
        }

        // GET: api/cursos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var cursonome = await _service.GetByNameAsync(nome);
            if (cursonome == null)
            {
                return NotFound($"Curso com nome: '{nome}' não foi encontrado.");
            }
            return Ok(cursonome);
        }
         
        // POST: api/cursos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            if (curso == null)
                return BadRequest("Corpo da requisição inválido.");

            await _service.CreateAsync(curso);
            return Ok();
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Curso curso)
        {
            var existe = await _service.GetByIdAsync(id);

            if (existe == null)
                return NotFound($"Curso com id: {id} não foi encontrado.");

            await _service.UpdateAsync(id, curso);

            return Ok(new { Message = "Curso atualizado com sucesso." });
        }

        // DELETE: api/cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existe = await _service.GetByIdAsync(id);
            if (existe == null)
                return NotFound($"Curso com id: {id} não foi encontrado.");

            await _service.DeleteAsync(id);
            return Ok(new { Message = "Curso deletado com sucesso." });
        }
    }
}
