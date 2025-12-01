using EduPay.Application.Service;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPay.Controllers
{
    [Route("api/turma")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly EduPayContext _context;

        private readonly TurmaService _service;

        public TurmasController(EduPayContext context, TurmaService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/turma
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/turmas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var turmaid = await _service.GetByIdAsync(id);
            if (turmaid == null)
            {
                return NotFound($"Curso com id: {id} não foi encontrado.");
            }
            return Ok(turmaid);
        }

        [HttpGet("{id}/curso")]
        public async Task<IActionResult> GetCursoByTurma(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var curso = await _service.GetCursoByTurmaAsync(id);

            if (curso == null)
                return NotFound($"Curso da turma {id} não foi encontrado.");

            return Ok(curso);
        }

        [HttpGet("{id}/matriculas")]
        public async Task<IActionResult> GetMatriculasByTurma(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var matriculas = await _service.GetMatriculasByTurmaAsync(id);

            if (matriculas == null || !matriculas.Any())
                return NotFound($"Nenhuma matrícula encontrada para a turma {id}.");

            return Ok(matriculas);
        }

        // GET: api/cursos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome inserido é invalido ou está vazio");
            }

            var turmanome = await _service.GetByNameAsync(nome);
            if (turmanome == null)
            {
                return NotFound($"Turma com nome: '{nome}' não foi encontrado.");
            }
            return Ok(turmanome);
        }

        // POST: api/turmas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Turma turma)
        {
            if (turma == null)
                return BadRequest("Corpo da requisição inválido.");

            if(turma.Periodo <= 0)
            {
                return BadRequest("O periodo inserido é invalido");
            }

            if (string.IsNullOrEmpty(turma.Nome))
            {
                return BadRequest("O nome inserido é invalido ou o campo está vazio");
            }

            turma.Curso = null;

            await _service.CreateAsync(turma);
            return Ok();
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Turma turma)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var existe = await _service.GetByIdAsync(id);

            if (existe == null)
                return NotFound($"Curso com id: {id} não foi encontrado.");

            await _service.UpdateAsync(id, turma);

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
                return NotFound($"Turma com id: {id} não foi encontrado.");

            await _service.DeleteAsync(id);
            return Ok(new { Message = "Turma deletado com sucesso." });
        }
    }
}
