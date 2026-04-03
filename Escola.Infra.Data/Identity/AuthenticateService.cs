using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Escola.Domain.Account;
using Escola.Domain.Entities;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Escola.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string senha)
    {
        var usuario = await _context.Usuario.FirstOrDefaultAsync(u => !u.Excluido && u.Email.ToLower() == email.ToLower());
        if (usuario == null)
            return false;

        using var hmac = new HMACSHA512(usuario.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != usuario.PasswordHash[i]) return false;
        }

        return true;
    }

    public string GenerateToken(int id, string email, string role)
    {
        var jwtSecretKey = _configuration["Jwt:SecretKey"];
        if (string.IsNullOrWhiteSpace(jwtSecretKey) || Encoding.UTF8.GetByteCount(jwtSecretKey) < 32)
        {
            throw new InvalidOperationException("Jwt:SecretKey deve ter no minimo 32 bytes (256 bits) para HS256.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, email.ToLower()),
            new Claim(ClaimTypes.Role, role.ToLower()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Usuario> GetUsuarioByEmail(string email)
    {
        return await _context.Usuario.FirstOrDefaultAsync(u => !u.Excluido && u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> UserExists(string email)
    {
        return await _context.Usuario.AnyAsync(u => !u.Excluido && u.Email.ToLower() == email.ToLower());
    }
}
