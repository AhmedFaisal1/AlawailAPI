using Microsoft.AspNetCore.Mvc;

namespace AlawailApi.Domain.Helpers
{
    public class BaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
        }
    }
}