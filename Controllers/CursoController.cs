using EduPay.Application.Service;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduPay.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly EduPayContext _context;
        private readonly CursoService _service;

        public CursoController(EduPayContext context, CursoService service)
        {
            _service = service;
            _context = context;
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
            if (id <= 0) {
                return BadRequest("O id informado deve ser maior que zero");
            }
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
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("O nome informado é invalido");
            }


            var cursonome = await _service.GetByNameAsync(nome);
            if (cursonome == null)
            {
                return NotFound($"Curso com nome: '{nome}' não foi encontrado.");
            }
            return Ok(cursonome);
        }

        // GET: api/cursos/{id}/turmas
        [HttpGet("{id}/turmas")]
        public async Task<IActionResult> GetTurmasByCurso(int id)
        {

            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var curso = await _service.GetByIdAsync(id);
            if (curso == null)
                return NotFound($"Curso com id {id} não foi encontrado.");

            var turmas = await _service.GetTurmasByCursoAsync(id);
            return Ok(turmas);
        }


        // POST: api/cursos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            if (curso == null)
                return BadRequest("Corpo da requisição inválido.");

            if (string.IsNullOrWhiteSpace(curso.Nome))
                return BadRequest("O nome do curso não pode ser vazio.");

            if (curso.CargaHoraria <= 0)
                return BadRequest("A carga horária deve ser maior que zero.");

            await _service.CreateAsync(curso);
            return Ok();
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Curso curso)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            if (curso == null)
                return BadRequest("O corpo da requisição é inválido.");

            if (string.IsNullOrWhiteSpace(curso.Nome))
                return BadRequest("O nome do curso não pode ser vazio.");

            if (curso.CargaHoraria <= 0)
                return BadRequest("A carga horária deve ser maior que zero.");

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

            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var existe = await _service.GetByIdAsync(id);
            if (existe == null)
                return NotFound($"Curso com id: {id} não foi encontrado.");

            await _service.DeleteAsync(id);
            return Ok(new { Message = "Curso deletado com sucesso." });
        }
    }
}
