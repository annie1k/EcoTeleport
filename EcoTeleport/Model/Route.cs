using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoTeleport.Model
{
    public class Route
    {
        [Key]
        public Guid route_uuid { get; set; }
        public DateTime departure_time { get; set; }
        public DateTime arrival_time { get; set; }
        public char origin { get; set; }
        public char destination { get; set; }
        public double footprint { get; set; }
        public TransportationMode transportation_mode { get; set; }
        
        [ForeignKey("User")]
        public Guid user_uuid { get; set; }
    
        public User User { get; set; }
        
        [ForeignKey("Goal")]
        public Guid goal_uuid { get; set; }
    
        public Goal Goal { get; set; }
    }
}