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
    public class StudentAccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStudentAccountServices _studentAccountService;

        public StudentAccountController(AppDbContext context, IStudentAccountServices studentAccountServices)
        {
            _context = context;
            _studentAccountService = studentAccountServices;
        }
        [HttpGet]
        public IActionResult GetStudentAccount()
        {
            var studentAccount = _studentAccountService.GetAll();
            return Ok(studentAccount);
        }
        
        [HttpGet("{id}")]
        public ActionResult<StudentAccount> GetstudentAccount(int id)
        {
            var studentAccount= _studentAccountService.GetStudentAccount(id);

            if (studentAccount == null)
            {
                return NotFound();
            }

            return Ok(studentAccount);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAccount(int id, StudentAccount studentAccount)
        {
            if (id != studentAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAccountExists(id))
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
        public IActionResult CreateStudentAccount(StudentAccountDto studentAccountDto)
        {
            var StudentAccount = _studentAccountService.CreateStudentAccount(studentAccountDto);
            return Ok(StudentAccount);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteStudentAccount(int id)
{
    var studentAccount = await _context.StudentAccounts.FindAsync(id);
    if (studentAccount == null)
    {
        return NotFound();
    }

    _context.StudentAccounts.Remove(studentAccount);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool StudentAccountExists(int id)
        {
            return _context.StudentAccounts.Any(e => e.Id == id);

        }
        
    }
    }