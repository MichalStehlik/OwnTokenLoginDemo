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

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new(ClaimTypes.Name, user.Username),
                new("sub", user.UserId.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(600),
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
