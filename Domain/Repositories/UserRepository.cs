using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        List<User> GetAll();
        User CreateUser(UserDto UserDto);
        User Find(int id);
        UserDto ToUserDto(User user);
        bool UserExists(int id);

    }
    public class UserRepositories : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepositories(AppDbContext context)
        {
            _context = context;
        }
        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User CreateUser(UserDto UserDto)
        {
            var User = ToUser(UserDto);
            _context.Users.Add(User);
            _context.SaveChanges();
            return User;
        }
        public User Find(int id)
        {
            return _context.Users.Find(id);
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        private User ToUser(UserDto UserDto)
        {
            return new User
            {
                Id = UserDto.Id,
                Fullname = UserDto.Fullname,
                username = UserDto.username,
                Email = UserDto.Email,
                Password = UserDto.Password,
                Role = UserDto.Role,
            };
        }
            public UserDto ToUserDto(User user)
            {
                return new UserDto
                {
                Id = user.Id,
                Fullname = user.Fullname,
                username = user.username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                };
            }

        }
}