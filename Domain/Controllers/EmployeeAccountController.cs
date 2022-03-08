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
    public class EmployeeAccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeAccountServices _employeeAccountService;

        public EmployeeAccountController(AppDbContext context, IEmployeeAccountServices employeeAccountServices)
        {
            _context = context;
            _employeeAccountService = employeeAccountServices;
        }
        [HttpGet]
        public IActionResult GetEmployeeAccount()
        {
            var employeeAccount = _employeeAccountService.GetAll();
            return Ok(employeeAccount);
        }
        
        [HttpGet("{id}")]
        public ActionResult<EmployeeAccount> GetemployeeAccount(int id)
        {
            var employeeAccount = _employeeAccountService.GetEmployeeAccount(id);

            if (employeeAccount == null)
            {
                return NotFound();
            }

            return Ok(employeeAccount);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAccount(int id, EmployeeAccount employeeAccount)
        {
            if (id != employeeAccount.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAccountExists(id))
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
        public IActionResult CreateEmployeeAccount(EmployeeAccountDto employeeAccountDto)
        {
            var EmployeeAccount = _employeeAccountService.CreateEmployeeAccount(employeeAccountDto);
            return Ok(EmployeeAccount);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteEmployeeAccount(int id)
{
    var employeeAccount = await _context.EmployeeAccounts.FindAsync(id);
    if (employeeAccount == null)
    {
        return NotFound();
    }

    _context.EmployeeAccounts.Remove(employeeAccount);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool EmployeeAccountExists(int id)
        {
            return _context.EmployeeAccounts.Any(e => e.EmployeeId == id);

        }
        
    }
    }