using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface IStudenTollRepository
    {
        StudentToll GetStudenToll(int id);
        List<StudentToll> GetAll();
        StudentToll CreateStudenToll(StudentTollDto StudenTollDto);
        StudentToll Find(int id);
        StudentTollDto ToStudenTollDto(StudentToll studenToll);
        bool StudenTollExists(int id);

    }
    public class StudenTollRepositories : IStudenTollRepository
    {
        private readonly AppDbContext _context;
        public StudenTollRepositories(AppDbContext context)
        {
            _context = context;
        }
        public StudentToll GetStudenToll(int id)
        {
            return _context.StudentTolls.Find(id);
        }
        public List<StudentToll> GetAll()
        {
            return _context.StudentTolls.ToList();
        }
        public StudentToll CreateStudenToll(StudentTollDto StudenTollDto)
        {
            var StudenToll = ToStudenToll(StudenTollDto);
            _context.StudentTolls.Add(StudenToll);
            _context.SaveChanges();
            return StudenToll;
        }
        public StudentToll Find(int id)
        {
            return _context.StudentTolls.Find(id);
        }
        public bool StudenTollExists(int id)
        {
            return _context.StudentTolls.Any(e => e.Id == id);
        }
        private StudentToll ToStudenToll(StudentTollDto StudenTollDto)
        {
            return new StudentToll
            {
                Id = StudenTollDto.Id,
                Year = StudenTollDto.Year,
                Amount = StudenTollDto.Amount,
                Registration = StudenTollDto.Registration,
                Currency = StudenTollDto.Currency,
            };
        }
            public StudentTollDto ToStudenTollDto(StudentToll studenToll)
            {
                return new StudentTollDto
                {
                Id = studenToll.Id,
                Year = studenToll.Year,
                Amount = studenToll.Amount,
                Registration = studenToll.Registration,
                Currency = studenToll.Currency,
                };
            }

        }
}