using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        List<Employee> GetAll();
        Employee CreateEmployee(EmployeeDto employeeDto);
        Employee Find(int id);
        EmployeeDto ToEmployeeDto(Employee employee);
        bool EmployeeExists(int id);

    }
    public class EmployeeRepositories : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepositories(AppDbContext context)
        {
            _context = context;
        }
        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }
        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee CreateEmployee(EmployeeDto employeeDto)
        {
            var Employee = ToEmployee(employeeDto);
            _context.Employees.Add(Employee);
            _context.SaveChanges();
            return Employee;
        }
        public Employee Find(int id)
        {
            return _context.Employees.Find(id);
        }
        public bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
        private Employee ToEmployee(EmployeeDto employeeDto)
        {
            return new Employee
            {
                EmployeeId = employeeDto.EmployeeId,
                FName = employeeDto.FName,
                LName = employeeDto.LName,
                Gender = employeeDto.Gender,
                Age = employeeDto.Age,
                Phone = employeeDto.City,
                City = employeeDto.Phone,
                Type  = employeeDto.Type,
            };
        }
            public EmployeeDto ToEmployeeDto(Employee Employee)
            {
                return new EmployeeDto
                {
                    EmployeeId = Employee.EmployeeId,
                    FName = Employee.FName,
                    LName = Employee.LName,
                    Gender = Employee.Gender,
                    Age = Employee.Age,
                    Phone = Employee.Phone,
                    City = Employee.City,
                    Type  = Employee.Type,
                };
            }

        }
}