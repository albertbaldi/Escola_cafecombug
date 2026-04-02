using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
    {
        await _usuarioService.AddAsync(usuarioPostDTO);
        return Ok(new { Message = "Usuário criado com sucesso!" });
    }

}
