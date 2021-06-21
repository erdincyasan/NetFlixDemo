using Microsoft.IdentityModel.Tokens;
using Netflix.Business.Abstract;
using Netflix.Business.StringInfos;
using Netflix.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Netflix.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public JwtSecurityToken GenerateJwt(User u)
        {

            SymmetricSecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken =
                new JwtSecurityToken(issuer: JwtInfo.Issuer, audience: JwtInfo.Audience, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration), signingCredentials: credentials, claims: GetClaims(u));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return securityToken;

        }

        private List<Claim> GetClaims(User u)
        {
            List<Claim> claims = new List<Claim>();
            if (u.UserName != null)
                claims.Add(new Claim(ClaimTypes.Name, u.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, u.UserID.ToString()));

            return null;
        }
    }
}
