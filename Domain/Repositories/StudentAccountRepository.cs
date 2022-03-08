using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IStudentAccountRepository
    {
        StudentAccount GetStudentAccount(int id);
        List<StudentAccount> GetAll();
        StudentAccount CreateStudentAccount(StudentAccountDto StudentAccountDto);
        StudentAccount Find(int id);
        StudentAccountDto ToStudentAccountDto(StudentAccount studentAccount);
        bool StudentAccountExists(int id);

    }
    public class StudentAccountRepositories : IStudentAccountRepository
    {
        private readonly AppDbContext _context;
        public StudentAccountRepositories(AppDbContext context)
        {
            _context = context;
        }
        public StudentAccount GetStudentAccount(int id)
        {
            return _context.StudentAccounts.Find(id);
        }
        public List<StudentAccount> GetAll()
        {
            return _context.StudentAccounts.ToList();
        }
        public StudentAccount CreateStudentAccount(StudentAccountDto StudentAccountDto)
        {
            var StudentAccount = ToStudentAccount(StudentAccountDto);
            _context.StudentAccounts.Add(StudentAccount);
            _context.SaveChanges();
            return StudentAccount;
        }
        public StudentAccount Find(int id)
        {
            return _context.StudentAccounts.Find(id);
        }
        public bool StudentAccountExists(int id)
        {
            return _context.StudentAccounts.Any(e => e.Id == id);
        }
        private StudentAccount ToStudentAccount(StudentAccountDto studentAccountDto)
        {
            return new StudentAccount
            {
                Id = studentAccountDto.Id,
                // StudentAccount = studentAccountDto.StudentAccount,
                Scholarships = studentAccountDto.Scholarships,
                ScholarshipsType = studentAccountDto.ScholarshipsType,
                Tols = studentAccountDto.Tols,
                Registration = studentAccountDto.Registration,
                Cuurency = studentAccountDto.Cuurency,
                Loan = studentAccountDto.Loan,
            };
        }
            public StudentAccountDto ToStudentAccountDto(StudentAccount StudentAccount)
            {
                return new StudentAccountDto
                {
                Id = StudentAccount.Id,
                // StudentAccount = StudentAccount.StudentAccount,
                Scholarships = StudentAccount.Scholarships,
                ScholarshipsType = StudentAccount.ScholarshipsType,
                Tols = StudentAccount.Tols,
                Registration = StudentAccount.Registration,
                Cuurency = StudentAccount.Cuurency,
                Loan = StudentAccount.Loan,
                };
            }

        }
}