using System.ComponentModel.DataAnnotations;

namespace EcoTeleport.Model
{
    public class User
    {
        [Key]
        public Guid user_uuid { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        
        public ICollection<UserGoal> UserGoals { get; set; }
        public ICollection<UserRoute> UserRoutes { get; set; }
    }
}