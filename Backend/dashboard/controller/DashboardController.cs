
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantDashboard.dashboard.service;
using RestaurantDashboard.security.user;
using RestaurantDashboard.security.user.domain;

namespace RestaurantDashboard.dashboard.controller;
[ApiController]
[Route("/api/stores")]
public class DashboardController(
    DashboardService dashboardService,
    UserManager<AppUser> userManager
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUserStores()
    {
        var userId = userManager.GetUserId(User);
        if (userId == null)
        {
            return Unauthorized();
        }
        
        return Ok(await dashboardService.GetAllStores(userId));
    }
} 