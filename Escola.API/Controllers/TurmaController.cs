using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
        {
            var createdTurma = await _turmaService.AddAsync(turmaPostDTO);
            if (createdTurma == null)
            {
                return BadRequest("Não foi possível criar a turma.");
            }

            // return Ok(createdTurma);
            return Ok(new { Message = "Turma criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
        {
            var updatedTurma = await _turmaService.UpdateAsync(turmaPutDTO);
            if (updatedTurma == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar a turma.");
            }

            // return Ok(updatedTurma);
            return Ok(new { Message = "Turma atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTurma(int id)
        {
            var deletedTurma = await _turmaService.DeleteAsync(id);
            if (deletedTurma == null)
            {
                return BadRequest("Ocorreu um erro ao deletar a turma.");
            }

            return Ok(new { Message = "Turma deletada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTurmaById(int id)
        {
            var turma = await _turmaService.GetByIdAsync(id);
            if (turma == null)
            {
                return NotFound("Turma não encontrada.");
            }

            return Ok(turma);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTurmas()
        {
            var turmas = await _turmaService.GetAllAsync();
            return Ok(turmas);
        }
    }
}