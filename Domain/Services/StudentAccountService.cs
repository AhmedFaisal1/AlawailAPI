using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IStudentAccountServices{
        StudentAccount GetStudentAccount(int Id);
        List<StudentAccountDto> GetAll();
        StudentAccount CreateStudentAccount(StudentAccountDto studentAccountDto);
    }
    public class StudentAccountServices: IStudentAccountServices
    {
        private readonly IStudentAccountRepository _StudentAccountRepository;
        public StudentAccountServices(IStudentAccountRepository studentAccountRepository){
            _StudentAccountRepository = studentAccountRepository;
        }
        public StudentAccount GetStudentAccount(int id){
            return _StudentAccountRepository.GetStudentAccount(id);
            }
            public StudentAccount CreateStudentAccount(StudentAccountDto studentAccountDto){
                return _StudentAccountRepository.CreateStudentAccount(studentAccountDto);
            }
            public List<StudentAccountDto> GetAll()
        {
            return _StudentAccountRepository.GetAll().Select(_StudentAccountRepository.ToStudentAccountDto).ToList();
        }


    }
}