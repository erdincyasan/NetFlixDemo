using Netflix.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Netflix.Business.Abstract
{
    public interface IJwtService
    {
        JwtSecurityToken GenerateJwt(User u);
    }
}
