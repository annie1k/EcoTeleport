using System.ComponentModel.DataAnnotations;

namespace EcoTeleport.Model
{
    public class User
    {
        [Key]
        public Guid user_uuid { get; set; }
        public char user_name { get; set; }
        public char password { get; set; }
    }
}