using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

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
        await _cursoService.AddAsync(cursoPostDTO);

        return Ok(new { Message = "Curso criado com sucesso!" });
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
    {
        await _cursoService.UpdateAsync(cursoPutDTO);

        return Ok(new { Message = "Curso atualizado com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCurso(int id)
    {
        await _cursoService.DeleteAsync(id);

        return Ok(new { Message = "Curso deletado com sucesso!" });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCursoById(int id)
    {
        var curso = await _cursoService.GetByIdAsync(id);

        return Ok(curso);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCursos()
    {
        var cursos = await _cursoService.GetAllAsync();

        return Ok(cursos);
    }
}
