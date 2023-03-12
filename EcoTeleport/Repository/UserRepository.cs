using EcoTeleport.Data;
using EcoTeleport.Interfaces;
using EcoTeleport.Model;

namespace EcoTeleport.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepositoryImplementation;

        public UserRepository(DataContext context)
        {
            _dataContext = context;
        }
        
        public User GetUserById(Guid id)
        {
            return _dataContext.Users.FirstOrDefault(u => u.user_uuid == id);
        }
        
        public User CreateUser(char name, char password)
        {
            var user = new User
            {
                user_uuid = Guid.NewGuid(),
                user_name = name,
                password = password
            };
        
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        
            return user;
        }
        
        public void UpdateUser(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }
        
        public void DeleteUserById(Guid userUuid)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.user_uuid == userUuid);
        
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dataContext.Users.OrderBy(u=> u.user_uuid).ToList();
        }
    }
}