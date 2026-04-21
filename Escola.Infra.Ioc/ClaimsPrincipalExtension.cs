using System;
using System.Security.Claims;

namespace Escola.Infra.Ioc;

public static class ClaimsPrincipalExtension
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim?.Value))
        {
            throw new UnauthorizedAccessException("Claim de identificação do usuário não encontrado.");
        }

        if (!int.TryParse(userIdClaim.Value, out var userId))
        {
            throw new UnauthorizedAccessException("Claim de identificação do usuário inválido.");
        }

        return userId;
    }
}
