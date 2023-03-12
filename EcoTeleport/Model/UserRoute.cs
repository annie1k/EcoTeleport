namespace EcoTeleport.Model;

public class UserRoute
{
    public Guid user_uuid { get; set; }
    public Guid route_uuid { get; set; }
    public User User { get; set; }
    public Route Route { get; set; }
}