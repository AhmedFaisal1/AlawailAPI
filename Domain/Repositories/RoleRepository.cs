using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IRoleRepository
    {
        Role GetRole(int id);
        List<Role> GetAll();
        Role CreateRole(RoleDto RoleDto);
        Role Find(int id);
        RoleDto ToRoleDto(Role role);
        bool RoleExists(int id);

    }
    public class RoleRepositories : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepositories(AppDbContext context)
        {
            _context = context;
        }
        public Role GetRole(int id)
        {
            return _context.Roles.Find(id);
        }
        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }
        public Role CreateRole(RoleDto RoleDto)
        {
            var Role = ToRole(RoleDto);
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return Role;
        }
        public Role Find(int id)
        {
            return _context.Roles.Find(id);
        }
        public bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RoleId == id);
        }
        private Role ToRole(RoleDto roleDto)
        {
            return new Role
            {
                RoleId = roleDto.RoleId,
                RoleName = roleDto.RoleName,
            };
        }
            public RoleDto ToRoleDto(Role Role)
            {
                return new RoleDto
                {
                    RoleId = Role.RoleId,
                    RoleName = Role.RoleName,
                };
            }

        }
}