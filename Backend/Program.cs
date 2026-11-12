
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantDashboard.security.dbConfigs;
using RestaurantDashboard.security.user;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var csb = new NpgsqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Local"))
{
    Username = Environment.GetEnvironmentVariable("USER"),
    Password = Environment.GetEnvironmentVariable("PASSWORD")
};

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(csb.ConnectionString));

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

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/auth").MapIdentityApi<AppUser>();
app.MapControllers();

app.Run();