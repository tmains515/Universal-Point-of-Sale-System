
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.security.dbConfigs;
using RestaurantDashboard.security.user;
using Npgsql;
using RestaurantDashboard.dashboard.controller;
using RestaurantDashboard.dashboard.repository;
using RestaurantDashboard.dashboard.service;

var builder = WebApplication.CreateBuilder(args);
var csb = new NpgsqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Local"))
{
    Username = Environment.GetEnvironmentVariable("USER"),
    Password = Environment.GetEnvironmentVariable("PASSWORD")
};

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(csb.ConnectionString).UseSnakeCaseNamingConvention());

builder.Services.AddIdentityApiEndpoints<AppUser>(o =>
    {
        o.Password.RequiredLength = 6;
        o.Lockout.MaxFailedAccessAttempts = 5;
        o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        o.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<DashboardController>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DashboardRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/auth").MapIdentityApi<AppUser>();
app.MapControllers();

app.Run();