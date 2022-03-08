using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IRoleServices{
        Role GetRole(int Id);
        List<RoleDto> GetAll();
        Role CreateRole(RoleDto roleDto);
    }
    public class RoleServices: IRoleServices
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleServices(IRoleRepository roleRepository){
            _RoleRepository = roleRepository;
        }
        public Role GetRole(int id){
            return _RoleRepository.GetRole(id);
            }
            public Role CreateRole(RoleDto roleDto){
                return _RoleRepository.CreateRole(roleDto);
            }
            public List<RoleDto> GetAll()
        {
            return _RoleRepository.GetAll().Select(_RoleRepository.ToRoleDto).ToList();
        }


    }
}