using Microsoft.AspNetCore.Mvc;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Services;
using AlawailApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;
namespace AlawailApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStudentServices _studentService;

        public StudentController(AppDbContext context, IStudentServices studentServices)
        {
            _context = context;
            _studentService = studentServices;
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
        var student = _studentService.GetAll();
            return Ok(student);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Student> Getstudent(int id)
        {
            var student = _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentDto studentDto)
        {
            var Student = _studentService.CreateStudent(studentDto);
            return Ok(Student);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteStudent(int id)
{
    var student = await _context.Students.FindAsync(id);
    if (student == null)
    {
        return NotFound();
    }

    _context.Students.Remove(student);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);

        }
        
    }
    }