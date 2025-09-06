using JcmSoft.Domain.Entities;
using JcmSoft.EFCore.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JcmSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos
                .AsNoTracking()
                .Select(d => new DepartamentoDTO
                {
                    Id = d.Id,
                    Nome = d.Nome,
                    Descricao = d.Descricao
                })
                .ToListAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DepartamentoDTO
                {
                    Id = d.Id,
                    Nome = d.Nome,
                    Descricao = d.Descricao
                })
                .FirstOrDefaultAsync();

            if (departamento == null)
            {
                return NotFound($"Departamento com ID {id} não encontrado.");
            }

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartamento([FromBody] DepartamentoDTO departamentoDto)
        {
            if (departamentoDto == null)
            {
                return BadRequest("Dados do departamento são obrigatórios.");
            }
            var departamento = new Departamento
            {
                Nome = departamentoDto.Nome,
                Descricao = departamentoDto.Descricao,
                DataCriacao = DateTime.UtcNow
            };
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            departamentoDto.Id = departamento.Id;
            return CreatedAtAction(nameof(GetDepartamento), new { id = departamento.Id }, departamentoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] DepartamentoDTO departamentoDto)
        {
            if (departamentoDto.Id != id)
            {
                return BadRequest("Dados do departamento são inválidos.");
            }

            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound($"Departamento com ID {id} não encontrado.");
            }

            departamento.Nome = departamentoDto.Nome;
            departamento.Descricao = departamentoDto.Descricao;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
           if(id <= 0)
            {
                return BadRequest("ID do departamento é inválido.");
            }

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound($"Departamento com ID {id} não encontrado.");
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
