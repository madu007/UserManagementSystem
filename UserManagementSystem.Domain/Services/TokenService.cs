using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Domain.Entities.Auth;

namespace UserManagementSystem.Domain.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, List<string> roles);
    }
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public string GenerateAccessToken(User user, List <string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:JwtBearer:SecretKey").Value);
            var minutres = Convert.ToDouble(_configuration.GetSection("Authentication:JwtBearer:AccessExpiration").Value);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "0000000000"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("firstName", user.FirstName),
                    new Claim("lastName", user.LastName),
                    new Claim(ClaimTypes.Country, "Nigeria")

                };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDesctiptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddMinutes(minutres),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                Issuer = _configuration.GetSection("Authentication:JwtBearer:Issuer").Value
            };

            var token = tokenHandler.CreateToken(tokenDesctiptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
