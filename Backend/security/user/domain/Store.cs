
namespace RestaurantDashboard.security.user.domain;
public class Store()
{
    public long Id { get; set; }
    public required AppUser User { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Configuration { get; set; }
    public List<Employee> Employees { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}