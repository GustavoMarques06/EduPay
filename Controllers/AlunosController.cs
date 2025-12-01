using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Data;
using EduPay.Application.Service;

namespace EduPay.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly EduPayContext _context;

        private readonly AlunoService _service;

        public AlunosController(EduPayContext context, AlunoService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetMatriculas()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpGet("{id}/matricula")]
        public async Task<IActionResult> GetMatriculaByAluno(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var matricula = await _service.GetMatriculaByAlunoAsync(id);
            if (matricula == null)
                return NotFound("Este aluno não possui matrícula.");

            return Ok(matricula);
        }


        [HttpGet("{id}/pagamentos")]
        public async Task<IActionResult> GetPagamentosByAluno(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return NotFound($"Aluno com id {id} não foi encontrado.");

            var pagamentos = await _context.Pagamentos
                .Where(p => p.Id_aluno == id)
                .ToListAsync();

            return Ok(pagamentos);
        }

        // PUT: api/Alunoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }
            var existe = await _service.GetByIdAsync(id);

            var existe = await _service.GetByIdAsync(id);

            if (existe == null)
                return NotFound($"Pagamento com id: {id} não foi encontrado.");

            

        // POST: api/Alunoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Aluno aluno)
        {
            if (aluno == null)
                return BadRequest("Corpo da requisição inválido.");

            if (string.IsNullOrEmpty(aluno.Nome))
            {
                return BadRequest("O nome inserido é invalido ou o campo está vazio");
            }

            var hoje = DateOnly.FromDateTime(DateTime.Today);
            if (aluno.Data_nascimento > hoje)
            {
                return BadRequest("Data de nascimento inserida é invalida");
            }

            aluno.Matricula = null;

            await _service.CreateAsync(aluno);
            return Ok();
        }

        // DELETE: api/Alunoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if(id <= 0)
            {
                return BadRequest("O id inserido deve ser maior que 0");
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
