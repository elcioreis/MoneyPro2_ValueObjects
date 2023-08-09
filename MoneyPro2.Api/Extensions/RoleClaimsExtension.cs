using MoneyPro2.Domain.Entities;
using System.Security.Claims;

namespace MoneyPro2.Api.Extensions;

public static class RoleClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName.Username),
            new Claim(ClaimTypes.Email, user.Email.Address)
        };
        return result;
    }
}
