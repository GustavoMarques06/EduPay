using EduPay.Application.Interface;
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
    [Route("api/matricula")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly EduPayContext _context;
        private readonly MatriculaService _service;
        private readonly PagamentoService _pagamentoservice;

        public MatriculasController(EduPayContext context, MatriculaService service, PagamentoService pagamentoservice)
        {
            _context = context;
            _service = service;
            _pagamentoservice = pagamentoservice;
        }

        // GET: api/Matriculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
        {
            return Ok(await _service.GetAllAsync());
        }


        // GET: api/Matriculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(int id)
        {
            if(id <= 0)
            {
                return BadRequest("O id fornecido deve ser maior que 0");
            }
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        [HttpGet("{id}/matriculas")]
        public async Task<IActionResult> GetMatriculasByTurma(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id fornecido deve ser maior que 0");
            }

            var turma = await _service.GetByIdAsync(id);
            if (turma == null)
                return NotFound($"Turma com id {id} não foi encontrada.");

            var matriculas = await _service.GetByTurmaAsync(id);

            return Ok(matriculas);
        }

        //Listar os pagamentos feitos por uma determinada matricula
        [HttpGet("{id}/pagamentos")]
        public async Task<IActionResult> GetPagamentosByMatricula(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id fornecido deve ser maior que 0");
            }

            var matricula = await _service.GetByIdAsync(id);
            if (matricula == null)
                return NotFound($"Matrícula com id {id} não foi encontrada.");

            var pagamentos = await _pagamentoservice.GetByMatriculaAsync(id);

            return Ok(pagamentos);
        }


        // PUT: api/Matriculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var existe = await _service.GetByIdAsync(id);

            if (existe == null)
                return NotFound($"Pagamento com id: {id} não foi encontrado.");

            await _service.UpdateAsync(id, matricula);

            return Ok(new { Message = "Pagamento atualizado com sucesso." });
        }

        // POST: api/Matriculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Matricula matricula)
        {
            if (matricula == null)
                return BadRequest("Corpo da requisição inválido.");

            var hoje = DateOnly.FromDateTime(DateTime.Today);


            if (matricula.data_matricula > hoje)
            {
                return BadRequest("Matriculas somente podem ser registradas no dia");
            }

          
            matricula.Turma = null;

            await _service.CreateAsync(matricula);
            return Ok();
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
