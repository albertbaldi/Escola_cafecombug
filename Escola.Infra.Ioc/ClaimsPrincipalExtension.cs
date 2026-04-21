using System;
using System.Security.Claims;

namespace Escola.Infra.Ioc;

public static class ClaimsPrincipalExtension
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new Exception("User ID claim not found.");
        }

        return int.Parse(userIdClaim.Value);
    }
}
