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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDepartmentServices _departmentService;

        public DepartmentController(AppDbContext context, IDepartmentServices departmentServices)
        {
            _context = context;
            _departmentService = departmentServices;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
            var department = _departmentService.GetAll();
            return Ok(department);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Department> Getdepartment(int id)
        {
            var department = _departmentService.GetDepartment(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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
        public IActionResult CreateDepartment(DepartmentDto departmentDto)
        {
            var Department = _departmentService.CreateDepartment(departmentDto);
            return Ok(Department);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteDepartment(int id)
{
    var department = await _context.Departments.FindAsync(id);
    if (department == null)
    {
        return NotFound();
    }

    _context.Departments.Remove(department);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);

        }
        
    }
    }