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
            await _notaService.AddAsync(notaPostDTO);

            return Ok(new { Message = "Nota criada com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNota(NotaPutDTO notaPutDTO)
        {
            await _notaService.UpdateAsync(notaPutDTO);

            return Ok(new { Message = "Nota atualizada com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNota(int id)
        {
            await _notaService.DeleteAsync(id);

            return Ok(new { Message = "Nota deletada com sucesso!" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNotaById(int id)
        {
            var nota = await _notaService.GetByIdAsync(id);

            return Ok(nota);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotas()
        {
            var notas = await _notaService.GetAllAsync();

            return Ok(notas);
        }
    }
}
