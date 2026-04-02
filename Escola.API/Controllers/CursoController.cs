using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCurso(CursoPostDTO cursoPostDTO)
        {
            var createdCurso = await _cursoService.AddAsync(cursoPostDTO);
            if (createdCurso == null)
            {
                return BadRequest("Não foi possível criar o curso.");
            }

            return Ok(new { Message = "Curso criado com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
        {
            var updatedCurso = await _cursoService.UpdateAsync(cursoPutDTO);
            if (updatedCurso == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar o curso.");
            }

            return Ok(new { Message = "Curso atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCurso(int id)
        {
            var deletedCurso = await _cursoService.DeleteAsync(id);
            if (deletedCurso == null)
            {
                return BadRequest("Ocorreu um erro ao deletar o curso.");
            }

            return Ok(new { Message = "Curso deletado com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCursoById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }

            return Ok(curso);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCursos()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }
    }
}
