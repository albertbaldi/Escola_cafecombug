using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmaController : ControllerBase
{
    private readonly ITurmaService _turmaService;
    public TurmaController(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> CreateTurma(TurmaPostDTO turmaPostDTO)
    {
        await _turmaService.AddAsync(turmaPostDTO);

        // return Ok(createdTurma);
        return Ok(new { Message = "Turma criada com sucesso!" });
    }

    [HttpPut]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
    {
        await _turmaService.UpdateAsync(turmaPutDTO);

        // return Ok(updatedTurma);
        return Ok(new { Message = "Turma atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> DeleteTurma(int id)
    {
        await _turmaService.DeleteAsync(id);

        return Ok(new { Message = "Turma deletada com sucesso!" });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> GetTurmaById(int id)
    {
        var turma = await _turmaService.GetByIdAsync(id);

        return Ok(turma);
    }


    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> GetAllTurmas()
    {
        var turmas = await _turmaService.GetAllAsync();

        return Ok(turmas);
    }

    [HttpGet("usuario")]
    [Authorize(Roles = "Aluno, Administrador")]
    public async Task<ActionResult> GetTurmasByIdUsuario()
    {
        var userId = User.GetUserId();

        var turmas = await _turmaService.GetTurmasByUsuario(userId);

        return Ok(turmas);
    }
}