using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IDepartmentServices{
        Department GetDepartment(int Id);
        List<DepartmentDto> GetAll();
        Department CreateDepartment(DepartmentDto departmentDto);
    }
    public class DepartmentServices: IDepartmentServices
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository){
            _DepartmentRepository = departmentRepository;
        }
        public Department GetDepartment(int id){
            return _DepartmentRepository.GetDepartment(id);
            }
            public Department CreateDepartment(DepartmentDto departmentDto){
                return _DepartmentRepository.CreateDepartment(departmentDto);
            }
            public List<DepartmentDto> GetAll()
        {
            return _DepartmentRepository.GetAll().Select(_DepartmentRepository.ToDepartmentDto).ToList();
        }


    }
}