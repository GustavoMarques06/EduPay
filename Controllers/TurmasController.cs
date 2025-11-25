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
            var turmaid = await _service.GetByIdAsync(id);
            if (turmaid == null)
            {
                return NotFound($"Curso com id: {id} não foi encontrado.");
            }
            return Ok(turmaid);
        }

        // GET: api/cursos/buscar/{nome}
        [HttpGet("buscar/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
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

            turma.Curso = null;

            await _service.CreateAsync(turma);
            return Ok();
        }

        // PUT: api/cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Turma turma)
        {
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
            var existe = await _service.GetByIdAsync(id);
            if (existe == null)
                return NotFound($"Turma com id: {id} não foi encontrado.");

            await _service.DeleteAsync(id);
            return Ok(new { Message = "Turma deletado com sucesso." });
        }
    }
}
