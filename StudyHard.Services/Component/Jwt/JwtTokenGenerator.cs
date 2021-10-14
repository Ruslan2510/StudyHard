using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using StudyHard.Dto.Auth;
using StudyHard.Dto.Config;

namespace StudyHard.Services.Component.Jwt
{
    public class JwtTokenGenerator
    {
        public static TokenDto GenerateToken(string email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = JwtConfig.GetSymmetricKey();
            var expiration = DateTime.Now.AddMinutes(JwtConfig.LifeTime);
            var jwtToken = new JwtSecurityToken(
                JwtConfig.Issuer,
                JwtConfig.Audience,
                authClaims,
                expires: expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(authSigningKey),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                
            return new TokenDto
            {
                Token = $"Bearer {token}",
                ExpiresAt = expiration,
            };
        }
    }

}