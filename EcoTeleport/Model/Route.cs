using System.ComponentModel.DataAnnotations;

namespace EcoTeleport.Model
{
    public class Route
    {
        [Key]
        public Guid route_uuid { get; set; }
        public DateTime departure_time { get; set; }
        public DateTime arrival_time { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public double footprint { get; set; }
        public TransportationMode transportation_mode { get; set; }
        public ICollection<GoalRoute> GoalRoutes { get; set; }
        public ICollection<UserRoute> UserRoutes { get; set; }
    }
}