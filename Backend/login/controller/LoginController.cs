using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantDashboard.login.dto;
using RestaurantDashboard.security.user;

namespace RestaurantDashboard.login.controller;

[ApiController]
[Route("api/[controller]")]
public class LoginController(
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var result = await signInManager.PasswordSignInAsync(
            request.Username,
            request.Password,
            isPersistent: request.RememberMe,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            // The sign-in above already proved this user exists.
            var user = await userManager.FindByNameAsync(request.Username);
            return Ok(new LoginResponseDto(user!.Id, user.UserName!, user.Email));
        }

        if (result.IsLockedOut)
        {
            return StatusCode(
                StatusCodes.Status423Locked,
                new { message = "This account is temporarily locked. Try again later." });
        }

        // Deliberately vague: do not reveal whether the username exists.
        return Unauthorized(new { message = "Invalid username or password." });
    }
}
