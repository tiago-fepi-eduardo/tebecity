using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Domain.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TE.BE.City.Domain
{
    public class UserDomain : IUserDomain
    {
        private IConfiguration _config;

        public UserDomain(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GenerateJWTToken(UserEntity userEntity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
