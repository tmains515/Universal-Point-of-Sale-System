
using Microsoft.AspNetCore.Mvc;
using RestaurantDashboard.dashboard.service;
using RestaurantDashboard.security.user.domain;

namespace RestaurantDashboard.dashboard.controller;
[ApiController]
[Route("/api/[controller]")]
public class DashboardController(
    DashboardService dashboardService
    ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> getUserStores([FromQuery] string userId)
    {
        return Ok(await dashboardService.GetAllStores(userId));
    }
} 