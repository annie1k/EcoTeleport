namespace EcoTeleport.Model;

public class UserGoal
{
    public Guid user_uuid { get; set; }
    public Guid goal_uuid { get; set; }
    public User User { get; set; }
    public Goal Goal { get; set; }
}