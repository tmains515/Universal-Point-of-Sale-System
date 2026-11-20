
using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.security.dbConfigs;
using RestaurantDashboard.security.user.domain;

namespace RestaurantDashboard.dashboard.repository;
public class DashboardRepository
{
    private readonly AppDbContext db;

    public Task<List<Store>> GetAllUserStores(string userId) => 
        db.Stores.AsNoTracking().Where(s => s.User.Id == userId).ToListAsync();
}