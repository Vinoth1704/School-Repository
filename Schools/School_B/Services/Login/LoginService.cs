using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace School.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public object TokenGenerator()
        {
            var Claims = new[]{new Claim(JwtRegisteredClaimNames.Sub,"Subject")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // var encryptingCredentials = new EncryptingCredentials(key, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);
            var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                new ClaimsIdentity(Claims),
                null,
                expires: DateTime.UtcNow.AddHours(1),
                null,
                signingCredentials: signIn
                // encryptingCredentials: encryptingCredentials
                );
            var Result = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
            };

            return Result;
        }
    }
}