using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Domain.Models.Auth;
using UserManagementSystem.Domain.Services;

namespace UserManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public AuthController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            try
            {
                var token = await _userAccountService.Login(signInModel);
                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<IActionResult> Create(SignInManager signUpModel)
        {
            try
            {
                
                var (success, responseMessage) = await _userAccountService.CreateUser(signUpModel);
                
                return Ok(new { result = responseMessage });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
