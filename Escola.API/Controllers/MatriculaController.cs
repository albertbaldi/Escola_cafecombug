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
            await _matriculaService.AddAsync(matriculaPostDTO);

            // return Ok(createdMatricula);
            return Ok(new { Message = "Matrícula criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDTO)
        {
            await _matriculaService.UpdateAsync(matriculaPutDTO);

            // return Ok(updatedMatricula);
            return Ok(new { Message = "Matrícula atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatricula(int id)
        {
            await _matriculaService.DeleteAsync(id);

            return Ok(new { Message = "Matrícula deletada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMatriculaById(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);

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
