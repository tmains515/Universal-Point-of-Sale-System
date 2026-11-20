using RestaurantDashboard.dashboard.repository;
using RestaurantDashboard.security.user.domain;

namespace RestaurantDashboard.dashboard.service;

public class DashboardService(DashboardRepository repository)
{
    public Task<List<Store>> GetAllStores(string userId) => repository.GetAllUserStores(userId); 
    
}