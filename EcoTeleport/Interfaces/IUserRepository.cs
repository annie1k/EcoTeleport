using EcoTeleport.Model;

namespace EcoTeleport.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User CreateUser(char name, char password);
        User GetUserById(Guid userId);
        void UpdateUser(User user);
        void DeleteUserById(Guid userUuid);
    }
}