using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantDashboard.security.user;

namespace RestaurantDashboard.login.controller;

[ApiController]
[Route("api/[controller]")]
public class LogoutController(SignInManager<AppUser> signInManager) : ControllerBase
{
    /// <summary>
    /// Clears the Identity application cookie.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }
}
