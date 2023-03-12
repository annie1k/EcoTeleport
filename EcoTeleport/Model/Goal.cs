using System.ComponentModel.DataAnnotations;

namespace EcoTeleport.Model
{
    public class Goal
    {
        [Key]
        public Guid goal_uuid { get; set; }
        public double daily_goal { get; set; }
    }
}