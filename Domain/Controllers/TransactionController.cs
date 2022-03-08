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
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITransactionServices _transactionService;

        public TransactionController(AppDbContext context, ITransactionServices transactionServices)
        {
            _context = context;
            _transactionService = transactionServices;
        }
        [HttpGet]
        public IActionResult GetTransaction()
        {
            var transaction = _transactionService.GetAll();
            return Ok(transaction);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Transaction> Gettransaction(int id)
        {
            var transaction= _transactionService.GetTransaction(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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
        public IActionResult CreateTransaction(TransactionDto transactionDto)
        {
            var Transaction = _transactionService.CreateTransaction(transactionDto);
            return Ok(Transaction);
        }
        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteTransaction(int id)
{
    var transaction = await _context.Transactions.FindAsync(id);
    if (transaction == null)
    {
        return NotFound();
    }

    _context.Transactions.Remove(transaction);
    await _context.SaveChangesAsync();

    return NoContent();
}

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);

        }
        
    }
    }