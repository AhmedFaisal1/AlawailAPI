using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IUserServices{
        User GetUser(int Id);
        List<UserDto> GetAll();
        User CreateUser(UserDto userDto);
    }
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _UserRepository;
        public UserServices(IUserRepository userRepository){
            _UserRepository = userRepository;
        }
        public User GetUser(int id){
            return _UserRepository.GetUser(id);
            }
            public User CreateUser(UserDto userDto){
                return _UserRepository.CreateUser(userDto);
            }
            public List<UserDto> GetAll()
        {
            return _UserRepository.GetAll().Select(_UserRepository.ToUserDto).ToList();
        }


    }
}