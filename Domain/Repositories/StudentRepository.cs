using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        List<Student> GetAll();
        Student CreateStudent(StudentDto StudentDto);
        Student Find(int id);
        StudentDto ToStudentDto(Student student);
        bool StudentExists(int id);

    }
    public class StudentRepositories : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepositories(AppDbContext context)
        {
            _context = context;
        }
        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student CreateStudent(StudentDto StudentDto)
        {
            var Student = ToStudent(StudentDto);
            _context.Students.Add(Student);
            _context.SaveChanges();
            return Student;
        }
        public Student Find(int id)
        {
            return _context.Students.Find(id);
        }
        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
        private Student ToStudent(StudentDto StudentDto)
        {
            return new Student
            {
                StudentId = StudentDto.StudentId,
                FName = StudentDto.FName,
                LName = StudentDto.LName,
                Age = StudentDto.Age,
                Gender = StudentDto.Gender,
                City = StudentDto.City,
            };
        }
            public StudentDto ToStudentDto(Student student)
            {
                return new StudentDto
                {
                StudentId = student.StudentId,
                FName = student.FName,
                LName = student.LName,
                Age = student.Age,
                Gender = student.Gender,
                City = student.City,
                };
            }

        }
}