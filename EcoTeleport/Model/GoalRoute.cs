using System.ComponentModel.DataAnnotations;

namespace EcoTeleport.Model
{
    public class GoalRoute
    {
        public Guid goal_uuid { get; set; }
        public Guid route_uuid { get; set; }
        public Goal Goal { get; set; }
        public Route Route { get; set; }
    }
}