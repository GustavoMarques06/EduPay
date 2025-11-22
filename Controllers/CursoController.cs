using EduPay.Application.Service;
using EduPay.Domain.Entities;
using EduPay.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _service;

        public CursoController(CursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            if (curso == null)
                return BadRequest("Corpo da requisição inválido.");

            var novoCurso = await _service.CreateAsync(curso);
            return Ok();
        }
    }
}
