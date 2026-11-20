
using Microsoft.AspNetCore.Identity;

namespace RestaurantDashboard.security.user;
public class AppUser : IdentityUser
{
 private string user_type { get; set; }
 
}