using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotaController : ControllerBase
{
    private readonly INotaService _notaService;

    public NotaController(INotaService notaService)
    {
        _notaService = notaService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> CreateNota(NotaPostDTO notaPostDTO)
    {
        await _notaService.AddAsync(notaPostDTO);

        return Ok(new { Message = "Nota criada com sucesso!" });
    }

    [HttpPut]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> UpdateNota(NotaPutDTO notaPutDTO)
    {
        await _notaService.UpdateAsync(notaPutDTO);

        return Ok(new { Message = "Nota atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> DeleteNota(int id)
    {
        await _notaService.DeleteAsync(id);

        return Ok(new { Message = "Nota deletada com sucesso!" });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> GetNotaById(int id)
    {
        var nota = await _notaService.GetByIdAsync(id);

        return Ok(nota);
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> GetAllNotas()
    {
        var notas = await _notaService.GetAllAsync();

        return Ok(notas);
    }

    [HttpGet("usuario/turma/{idTurma}")]
    [Authorize(Roles = "Aluno, Administrador")]
    public async Task<ActionResult> GetNotasByTurmaUsuario(int idTurma)
    {
        var idUsuario = User.GetUserId();
        var notas = await _notaService.GetNotasByTurmaUsuario(idTurma, idUsuario);

        return Ok(notas);
    }
}
