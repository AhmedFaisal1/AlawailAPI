using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IStudentServices{
        Student GetStudent(int Id);
        List<StudentDto> GetAll();
        Student CreateStudent(StudentDto studentDto);
    }
    public class StudentServices: IStudentServices
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentServices(IStudentRepository studentRepository){
            _StudentRepository = studentRepository;
        }
        public Student GetStudent(int id){
            return _StudentRepository.GetStudent(id);
            }
            public Student CreateStudent(StudentDto studentDto){
                return _StudentRepository.CreateStudent(studentDto);
            }
            public List<StudentDto> GetAll()
        {
            return _StudentRepository.GetAll().Select(_StudentRepository.ToStudentDto).ToList();
        }


    }
}