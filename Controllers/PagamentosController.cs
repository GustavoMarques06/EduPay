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
        
        private readonly PagamentoService _service;

        public PagamentosController(PagamentoService service)
        {
            
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            var pagamentos = await _service.GetAllAsync();
            return Ok(pagamentos);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            if(id <= 0)
            {
                return BadRequest("O id inserido deve ser maior que 0");
            }
            var pagamento = await _service.GetByIdAsync(id);

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

        
        [HttpGet("periodo")]
        public async Task<IActionResult> GetPorPeriodo(
            [FromQuery] DateOnly inicio,
            [FromQuery] DateOnly fim)
        {
            var lista = await _service.GetPagamentosPorPeriodoAsync(inicio, fim);
            return Ok(lista);
        }

        
        [HttpGet("filtrar")]
        public async Task<IActionResult> FiltrarPorValor(
            [FromQuery] double? min,
            [FromQuery] double? max)
        {
            var lista = await _service.FiltrarPagamentosPorValorAsync(min, max);
            return Ok(lista);
        }
        
        [HttpGet("CodigoTransacao/{Cod_transacao}")]
        public async Task<ActionResult<Pagamento>> GetByCode(string Cod_transacao)
        {
            if (Cod_transacao == null)
            {
                return BadRequest("Codigo de transação não encontrado.");
            }
            var codigo = await _service.GetByCodAsync(Cod_transacao);
            return Ok(codigo);
        }


        // PUT: api/Pagamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var existe = await _service.GetByIdAsync(id);

            if (existe == null)
                return NotFound($"Pagamento com id: {id} não foi encontrado.");

            await _service.UpdateAsync(id, pagamento);

            return Ok(new { Message = "Pagamento atualizado com sucesso." });
        }

        // POST: api/Pagamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pagamento pagamento)
        {
            var hoje = DateOnly.FromDateTime(DateTime.Now);
            if(pagamento.Data_pagamento > hoje)
            {
                return BadRequest("Data inserida é invalida");
            }

            if (pagamento == null)
                return BadRequest("Corpo da requisição inválido.");


            var criado = await _service.CreateAsync(pagamento);
            return Ok(criado);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("O id informado deve ser maior que zero");
            }

            var existe = await _service.GetByIdAsync(id);
            if (existe == null)
                return NotFound($"Pagamento com id: {id} não foi encontrado.");

            await _service.DeleteAsync(id);
            return Ok(new { Message = "Pagamento deletado com sucesso." });
        }

        
    }
}
