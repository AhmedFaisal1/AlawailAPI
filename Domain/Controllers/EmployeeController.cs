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
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeServices _employeeService;

        public EmployeeController(AppDbContext context, IEmployeeServices employeeServices)
        {
            _context = context;
            _employeeService = employeeServices;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employee = _employeeService.GetAll();
            return Ok(employee);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Employee> Getemployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            var Employee = _employeeService.CreateEmployee(employeeDto);
            return Ok(Employee);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteEmployee(int id)
{
    var employee = await _context.Employees.FindAsync(id);
    if (employee == null)
    {
        return NotFound();
    }

    _context.Employees.Remove(employee);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);

        }
        
    }
    }