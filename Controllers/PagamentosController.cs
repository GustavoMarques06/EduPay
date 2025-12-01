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
    [Route("api/pagamentos")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly EduPayContext _context;
        private readonly PagamentoService _service;

        public PagamentosController(EduPayContext context, PagamentoService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            var pagamentos = await _service.GetAllAsync();
            return Ok(pagamentos);
        }

        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            if(id <= 0)
            {
                return BadRequest("O id inserido deve ser maior que 0");
            }
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        [HttpGet("alunos/{alunoId}/total")]
        public async Task<IActionResult> GetTotalPorAluno(int alunoId)
        {
            if(alunoId < 0)
            {
                return BadRequest("O id inserido deve ser maior que 0");
            }
            var total = await _service.GetTotalPagoPorAlunoAsync(alunoId);
            return Ok(new { alunoId, total });
        }

        // 3B — Total pago por matrícula
        [HttpGet("matriculas/{matriculaId}/total")]
        public async Task<IActionResult> GetTotalPorMatricula(int matriculaId)
        {
            if(matriculaId < 0)
            {
                return BadRequest("O id inserido deve ser maior que 0");
            }
            var total = await _service.GetTotalPagoPorMatriculaAsync(matriculaId);
            return Ok(new { matriculaId, total });
        }

        // 3C — Pagamentos por período
        [HttpGet("periodo")]
        public async Task<IActionResult> GetPorPeriodo(
            [FromQuery] DateOnly inicio,
            [FromQuery] DateOnly fim)
        {
            var lista = await _service.GetPagamentosPorPeriodoAsync(inicio, fim);
            return Ok(lista);
        }

        // 3E — Filtrar por valor
        [HttpGet("filtrar")]
        public async Task<IActionResult> FiltrarPorValor(
            [FromQuery] double? min,
            [FromQuery] double? max)
        {
            var lista = await _service.FiltrarPagamentosPorValorAsync(min, max);
            return Ok(lista);
        }

        // PUT: api/Pagamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pagamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pagamento pagamento)
        {
            if (string.IsNullOrEmpty(pagamento.Cod_transacao))
            {
                return BadRequest("O codigo inserido é invalido ou campo está vazio");
            }

            var hoje = DateOnly.FromDateTime(DateTime.Now);
            if(pagamento.Data_pagamento > hoje)
            {
                return BadRequest("Data inserida é invalida");
            }

            if (pagamento == null)
                return BadRequest("Corpo da requisição inválido.");

            // Evita o EF tentar criar objetos de navegação
            pagamento.Aluno = null;
            pagamento.Matricula = null;

            var criado = await _service.CreateAsync(pagamento);
            return Ok(criado);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
