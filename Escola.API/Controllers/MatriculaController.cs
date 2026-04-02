using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDTO)
        {
            var createdMatricula = await _matriculaService.AddAsync(matriculaPostDTO);
            if (createdMatricula == null)
            {
                return BadRequest("Não foi possível criar a matrícula.");
            }

            // return Ok(createdMatricula);
            return Ok(new { Message = "Matrícula criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDTO)
        {
            var updatedMatricula = await _matriculaService.UpdateAsync(matriculaPutDTO);
            if (updatedMatricula == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar a matrícula.");
            }

            // return Ok(updatedMatricula);
            return Ok(new { Message = "Matrícula atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatricula(int id)
        {
            var deletedMatricula = await _matriculaService.DeleteAsync(id);
            if (deletedMatricula == null)
            {
                return BadRequest("Ocorreu um erro ao deletar a matrícula.");
            }

            return Ok(new { Message = "Matrícula deletada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMatriculaById(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);
            if (matricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }

            return Ok(matricula);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMatriculas()
        {
            var matriculas = await _matriculaService.GetAllAsync();
            return Ok(matriculas);
        }
    }
}
