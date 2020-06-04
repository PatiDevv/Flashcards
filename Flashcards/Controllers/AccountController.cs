using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Users;
using Flashcards.Infrastructure.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
            => Json(await _userService.GetAccountAsync(UserId));

        [HttpPost("register")]

        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Name, command.Password);
            return Created("/account", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
             => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
