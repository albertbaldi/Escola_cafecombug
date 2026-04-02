using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNota(NotaPostDTO notaPostDTO)
        {
            var createdNota = await _notaService.AddAsync(notaPostDTO);
            if (createdNota == null)
            {
                return BadRequest("Não foi possível criar a nota.");
            }

            return Ok(new { Message = "Nota criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNota(NotaPutDTO notaPutDTO)
        {
            var updatedNota = await _notaService.UpdateAsync(notaPutDTO);
            if (updatedNota == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar a nota.");
            }

            return Ok(new { Message = "Nota atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNota(int id)
        {
            var deletedNota = await _notaService.DeleteAsync(id);
            if (deletedNota == null)
            {
                return BadRequest("Ocorreu um erro ao deletar a nota.");
            }

            return Ok(new { Message = "Nota deletada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotaById(int id)
        {
            var nota = await _notaService.GetByIdAsync(id);
            if (nota == null)
            {
                return NotFound("Nota não encontrada.");
            }

            return Ok(nota);
        }
    }
}
