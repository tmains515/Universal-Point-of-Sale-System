
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.security.user;
using RestaurantDashboard.security.user.domain;

namespace RestaurantDashboard.security.dbConfigs;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("rest_pos");
        builder.Entity<Store>();
        builder.Entity<Employee>();
    }
}