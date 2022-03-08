using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IEmployeeServices{
        Employee GetEmployee(int Id);
        List<EmployeeDto> GetAll();
        Employee CreateEmployee(EmployeeDto employeeDto);
    }
    public class EmployeeServices: IEmployeeServices

    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository){
            _EmployeeRepository = employeeRepository;
        }
        public Employee GetEmployee(int id){
            return _EmployeeRepository.GetEmployee(id);
            }
            public Employee CreateEmployee(EmployeeDto employeeDto){
                return _EmployeeRepository.CreateEmployee(employeeDto);
            }
            public List<EmployeeDto> GetAll()
        {
            return _EmployeeRepository.GetAll().Select(_EmployeeRepository.ToEmployeeDto).ToList();
        }


    }
}