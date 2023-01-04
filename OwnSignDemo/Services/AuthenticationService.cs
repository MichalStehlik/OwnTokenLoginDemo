using Microsoft.IdentityModel.Tokens;
using OwnSignDemo.Data;
using OwnSignDemo.Interfaces;
using OwnSignDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OwnSignDemo.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        internal readonly IRepository<int, User> _repo;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IRepository<int, User> repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }

        public AuthenticationToken? Authenticate(User user)
        {
            var u = _repo.DbSet.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (u == null)
            {
                return null;
            }
            return CreateAuthenticationToken(u);
        }

        private AuthenticationToken CreateAuthenticationToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            int validityDuration = 10;
            int.TryParse(_configuration["JWT:Expiration"], out validityDuration);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Username),
                    new("sub", user.UserId.ToString()), 
                    new("admin", user.Admin ? "1" : "0"),
                }),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(validityDuration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationToken()
            {
                Token = tokenHandler.WriteToken(token),
            };
        }
    }
}
