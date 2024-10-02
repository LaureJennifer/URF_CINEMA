using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace URF_Cinema.Application.ValueObjects.Common
{
    public static class TokenDecoding
    {
        public static ClaimsPrincipal DecodeToken(string token)
        {
            var secretKey = ConstsToken.SecretKey;
            var key = Encoding.ASCII.GetBytes(secretKey ?? "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            return principal;
        }
    }
}
