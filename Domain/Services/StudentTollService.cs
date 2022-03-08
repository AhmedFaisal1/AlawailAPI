using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface IStudentTollServices{
        StudentToll GetStudentToll(int Id);
        List<StudentTollDto> GetAll();
        StudentToll CreateStudentToll(StudentTollDto studentTollDto);
    }
    public class StudentTollServices: IStudentTollServices
    {
        private readonly IStudenTollRepository _StudentTollRepository;
        public StudentTollServices(IStudenTollRepository studentTollRepository){
            _StudentTollRepository = studentTollRepository;
        }
        public StudentToll GetStudentToll(int id){
            return _StudentTollRepository.GetStudenToll(id);
            }
            public StudentToll CreateStudentToll(StudentTollDto studentTollDto){
                return _StudentTollRepository.CreateStudenToll(studentTollDto);
            }
            public List<StudentTollDto> GetAll()
        {
            return _StudentTollRepository.GetAll().Select(_StudentTollRepository.ToStudenTollDto).ToList();
        }


    }
}