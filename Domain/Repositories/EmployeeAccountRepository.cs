using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IEmployeeAccountRepository
    {
        EmployeeAccount GetEmployeeAccount(int id);
        List<EmployeeAccount> GetAll();
        EmployeeAccount CreateEmployeeAccount(EmployeeAccountDto EmployeeAccountDto);
        EmployeeAccount Find(int id);
        EmployeeAccountDto ToEmployeeAccountDto(EmployeeAccount employeeAccount);
        bool EmployeeAccountExists(int id);

    }
    public class EmployeeAccountRepositories : IEmployeeAccountRepository
    {
        private readonly AppDbContext _context;
        public EmployeeAccountRepositories(AppDbContext context)
        {
            _context = context;
        }
        public EmployeeAccount GetEmployeeAccount(int id)
        {
            return _context.EmployeeAccounts.Find(id);
        }
        public List<EmployeeAccount> GetAll()
        {
            return _context.EmployeeAccounts.ToList();
        }
        public EmployeeAccount CreateEmployeeAccount(EmployeeAccountDto EmployeeAccountDto)
        {
            var EmployeeAccount = ToEmployeeAccount(EmployeeAccountDto);
            _context.EmployeeAccounts.Add(EmployeeAccount);
            _context.SaveChanges();
            return EmployeeAccount;
        }
        public EmployeeAccount Find(int id)
        {
            return _context.EmployeeAccounts.Find(id);
        }
        public bool EmployeeAccountExists(int id)
        {
            return _context.EmployeeAccounts.Any(e => e.EmployeeId == id);
        }
        private EmployeeAccount ToEmployeeAccount(EmployeeAccountDto employeeAccountDto)
        {
            return new EmployeeAccount
            {
                EmployeeId = employeeAccountDto.EmployeeId,
                Salary = employeeAccountDto.Salary,
                Tax = employeeAccountDto.Tax,
                Ammount = employeeAccountDto.Ammount,
                BankAccountNumber = employeeAccountDto.BankAccountNumber,
                Currency = employeeAccountDto.Currency,
            };
        }
        public EmployeeAccountDto ToEmployeeAccountDto(EmployeeAccount EmployeeAccount)
        {
            return new EmployeeAccountDto
            {
                EmployeeId = EmployeeAccount.EmployeeId,
                Salary = EmployeeAccount.Salary,
                Tax = EmployeeAccount.Tax,
                Ammount = EmployeeAccount.Ammount,
                BankAccountNumber = EmployeeAccount.BankAccountNumber,
                Currency = EmployeeAccount.Currency,
            };
        }

    }
}