using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

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
        await _turmaService.AddAsync(turmaPostDTO);

        // return Ok(createdTurma);
        return Ok(new { Message = "Turma criada com sucesso!" });
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTurma(TurmaPutDTO turmaPutDTO)
    {
        await _turmaService.UpdateAsync(turmaPutDTO);

        // return Ok(updatedTurma);
        return Ok(new { Message = "Turma atualizada com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTurma(int id)
    {
        await _turmaService.DeleteAsync(id);

        return Ok(new { Message = "Turma deletada com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTurmaById(int id)
    {
        var turma = await _turmaService.GetByIdAsync(id);

        return Ok(turma);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllTurmas()
    {
        var turmas = await _turmaService.GetAllAsync();

        return Ok(turmas);
    }
}