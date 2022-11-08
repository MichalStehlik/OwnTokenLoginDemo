using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OwnSignDemo.Interfaces;
using OwnSignDemo.Models;
using OwnSignDemo.Models.InputModels;

namespace OwnSignDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Interfaces.IAuthenticationService _authenticationService;
        internal readonly IRepository<int, User> _repo;
        private readonly ILogger<UsersController> _logger;

        public AuthenticationController(Interfaces.IAuthenticationService authenticationService, IRepository<int, User> repo, ILogger<UsersController> logger)
        {
            _authenticationService = authenticationService;
            _repo = repo;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginIM user)
        {
            var token = _authenticationService.Authenticate(new Models.User { Username = user.Username, Password = user.Password});

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User user)
        {
            _repo.Create(user);
            await _repo.SaveAsync();
            _logger.LogError("User " + user.UserId + " created.");
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            throw new NotImplementedException();
        }
    }
}
