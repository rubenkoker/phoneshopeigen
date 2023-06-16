using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using PhoneShop.API.Models;
using PhoneShop.Contracts.Interfaces;
using PhoneShop.Domain;
using System.Security.Claims;
using System.Text;
using ValidationExtensions;

namespace PhoneShop.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOptions<ApiBehaviorOptions> _apiBehaviorOptions;

        public AuthController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<ApiBehaviorOptions> apiBehaviorOptions,
            IJwtAuthManager jwtAuthManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _apiBehaviorOptions = apiBehaviorOptions;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _signInManager
                    .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    var claims = new[]
                    {
                        new Claim("Username", user.UserName),
                        new Claim("Role", "guest"),
                        new Claim("Email", user.Email)
                    };

                    var jwtResult = _jwtAuthManager.GenerateTokens(user.UserName, claims, DateTime.Now);

                    return Ok(new
                    {
                        UserName = user.UserName,
                        Role = "guest",
                        AccessToken = jwtResult.AccessToken,
                        RefreshToken = jwtResult.RefreshToken.TokenString
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] LoginModel model, [FromQuery] string returnUrl = null)
        {
            if (model.Email.IsValidEmail())
                try
                {
                    var user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (!result.Succeeded)
                        return AddIdentityErrors(result);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    return Ok(new
                    {
                        Succes = true,
                        ConfirmationCode = code
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        ex.Message,
                        InnerExceptionMessage = ex.InnerException?.Message
                    });
                }
            else
            {
                return BadRequest(new
                {
                    InnerExceptionMessage = "not a valid email adress"
                });
            }
        }

        private IActionResult AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}