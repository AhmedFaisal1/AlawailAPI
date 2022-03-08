using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IEmployeeAccountServices{
        EmployeeAccount GetEmployeeAccount(int Id);
        List<EmployeeAccountDto> GetAll();
        EmployeeAccount CreateEmployeeAccount(EmployeeAccountDto employeeAccountDto);
    }
    public class EmployeeAccountServices: IEmployeeAccountServices
    {
        private readonly IEmployeeAccountRepository _EmployeeAccountRepository;
        public EmployeeAccountServices(IEmployeeAccountRepository employeeAccountRepository){
            _EmployeeAccountRepository = employeeAccountRepository;
        }
        public EmployeeAccount GetEmployeeAccount(int id){
            return _EmployeeAccountRepository.GetEmployeeAccount(id);
            }
            public EmployeeAccount CreateEmployeeAccount(EmployeeAccountDto employeeAccountDto){
                return _EmployeeAccountRepository.CreateEmployeeAccount(employeeAccountDto);
            }
            public List<EmployeeAccountDto> GetAll()
        {
            return _EmployeeAccountRepository.GetAll().Select(_EmployeeAccountRepository.ToEmployeeAccountDto).ToList();
        }


    }
}