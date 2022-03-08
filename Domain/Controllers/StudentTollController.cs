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
    public class StudentTollController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStudentTollServices _studentTollService;

        public StudentTollController(AppDbContext context, IStudentTollServices studentTollServices)
        {
            _context = context;
            _studentTollService = studentTollServices;
        }
        [HttpGet]
        public IActionResult GetStudentToll()
        {
            var studentToll = _studentTollService.GetAll();
            return Ok(studentToll);
        }
        
        [HttpGet("{id}")]
        public ActionResult<StudentToll> GetstudentToll(int id)
        {
            var studentToll= _studentTollService.GetStudentToll(id);

            if (studentToll == null)
            {
                return NotFound();
            }

            return Ok(studentToll);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentToll(int id, StudentToll studentToll)
        {
            if (id != studentToll.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentToll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTollExists(id))
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
        public IActionResult CreateStudentToll(StudentTollDto studentTollDto)
        {
            var StudentToll = _studentTollService.CreateStudentToll(studentTollDto);
            return Ok(StudentToll);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteStudentToll(int id)
{
    var studentToll = await _context.StudentTolls.FindAsync(id);
    if (studentToll == null)
    {
        return NotFound();
    }

    _context.StudentTolls.Remove(studentToll);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool StudentTollExists(int id)
        {
            return _context.StudentTolls.Any(e => e.Id == id);

        }
        
    }
    }