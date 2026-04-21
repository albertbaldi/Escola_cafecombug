using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Account;
using Escola.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthenticate _authenticate;
    public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
    {
        _usuarioService = usuarioService;
        _authenticate = authenticate;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
    {
        if (await _authenticate.UserExists(usuarioPostDTO.Email))
            return BadRequest(new { Message = "Já existe um usuário com esse email." });

        var usuario = await _usuarioService.AddAsync(usuarioPostDTO);
        var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);

        return Ok(new { Nome = usuario.Nome, Token = token });
    }

    [HttpPost("login")]
    public async Task<ActionResult> GetTokenUsuario(UsuarioLoginDTO usuarioLoginDTO)
    {
        var usuario = await _authenticate.GetUsuarioByEmail(usuarioLoginDTO.Email);
        if (usuario == null)
            return BadRequest(new { Message = "Usuário ou senha inválidos." });

        var usuarioValido = await _authenticate.AuthenticateAsync(usuarioLoginDTO.Email, usuarioLoginDTO.Senha);
        if (!usuarioValido)
            return BadRequest(new { Message = "Usuário ou senha inválidos." });

        var token = _authenticate.GenerateToken(usuario.Id, usuario.Email.ToLower(), usuario.Perfil);

        return Ok(new { Nome = usuario.Nome, Token = token });
    }
}
