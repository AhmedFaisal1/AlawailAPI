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
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRoleServices _roleService;

        public RoleController(AppDbContext context, IRoleServices roleServices)
        {
            _context = context;
            _roleService = roleServices;
        }
        [HttpGet]
        public IActionResult GetRole()
        {
            var role = _roleService.GetAll();
            return Ok(role);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Role> Getrole(int id)
        {
            var role = _roleService.GetRole(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public IActionResult CreateRole(RoleDto roleDto)
        {
            var Role = _roleService.CreateRole(roleDto);
            return Ok(Role);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteRole(int id)
{
    var role = await _context.Roles.FindAsync(id);
    if (role == null)
    {
        return NotFound();
    }

    _context.Roles.Remove(role);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.RoleId == id);

        }
        
    }
    }