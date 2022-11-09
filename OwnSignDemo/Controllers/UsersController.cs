using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnSignDemo.Models;
using OwnSignDemo.Services;

namespace OwnSignDemo.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repo;
        private readonly ILogger<UsersController> _logger;
        private readonly IAuthorizationService _authorizationService;

        public UsersController(UserRepository repo, ILogger<UsersController> logger, IAuthorizationService authorizationService)
        {
            _repo = repo;
            _logger = logger;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return _repo.List<string>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            User? user = await _repo.ReadAsync(id);
            if (user == null)
            {
                _logger.LogError("User " + id + " does not exists.");
                return NotFound("User " + id + " does not exists. ");
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUserAsync(User user)
        {
            _repo.Create(user);
            await _repo.SaveAsync();
            _logger.LogError("User " + user.UserId + " created.");
            return CreatedAtAction(nameof(GetUserAsync), new { id = user.UserId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _repo.ReadAsync(id);
            if (user == null)
            {
                _logger.LogError("User " + id + " does not exists.");
                return NotFound("User " + id + " does not exists. ");
            }

            _repo.Delete(user);
            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User value)
        {
            if (id != value.UserId)
            {
                return BadRequest("Data content and Id does not match.");
            }

            var originalUser = await _repo.ReadAsync(id);
            if (originalUser == null)
            {
                return NotFound("user does not exists");
            };
            originalUser.Username = value.Username;
            originalUser.Password = value.Password;
            _repo.Update(originalUser);
            await _repo.SaveAsync();
            return Ok(originalUser);
        }

        [HttpPatch]
        public async Task<ActionResult<User>> PatchUser([FromBody] JsonPatchDocument<User> patchDoc)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0
            if (patchDoc != null)
            {
                var user = new User();
                patchDoc.ApplyTo(user, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return new ObjectResult(user);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
