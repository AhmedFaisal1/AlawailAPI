using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int id);
        List<Department> GetAll();
        Department CreateDepartment(DepartmentDto departmentDto);
        Department Find(int id);
        DepartmentDto ToDepartmentDto(Department department);
        bool DepartmentExists(int id);

    }
    public class DepartmentRepositories : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepositories(AppDbContext context)
        {
            _context = context;
        }
        public Department GetDepartment(int id)
        {
            return _context.Departments.Find(id);
        }
        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public Department CreateDepartment(DepartmentDto departmentDto)
        {
            var Department = ToDepartment(departmentDto);
            _context.Departments.Add(Department);
            _context.SaveChanges();
            return Department;
        }
        public Department Find(int id)
        {
            return _context.Departments.Find(id);
        }
        public bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
        private Department ToDepartment(DepartmentDto departmentDto)
        {
            return new Department
            {
                DepartmentId = departmentDto.DepartmentId,
                DepartmentName = departmentDto.DepartmentName,
                DepartmentHeadManager  = departmentDto.DepartmentHeadManager ,
            };
        }
            public DepartmentDto ToDepartmentDto(Department Department)
            {
                return new DepartmentDto
                {
                    DepartmentId = Department.DepartmentId,
                    DepartmentName = Department.DepartmentName,
                    DepartmentHeadManager  = Department.DepartmentHeadManager,
                };
            }

        }
}