using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Transaction GetTransaction(int id);
        List<Transaction> GetAll();
        Transaction CreateTransaction(TransactionDto TransactionDto);
        Transaction Find(int id);
        TransactionDto ToTransactionDto(Transaction transaction);
        bool TransactionExists(int id);

    }
    public class TransactionRepositories : ITransactionRepository
    {
        private readonly AppDbContext _context;
        public TransactionRepositories(AppDbContext context)
        {
            _context = context;
        }
        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }
        public List<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }
        public Transaction CreateTransaction(TransactionDto TransactionDto)
        {
            var Transaction = ToTransaction(TransactionDto);
            _context.Transactions.Add(Transaction);
            _context.SaveChanges();
            return Transaction;
        }
        public Transaction Find(int id)
        {
            return _context.Transactions.Find(id);
        }
        public bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
        private Transaction ToTransaction(TransactionDto TransactionDto)
        {
            return new Transaction
            {
                Id = TransactionDto.Id,
                Amount = TransactionDto.Amount,
                LeftOver = TransactionDto.LeftOver,
                Payments = TransactionDto.Payments,
                UserId = TransactionDto.UserId,
                StudentId = TransactionDto.StudentId,
                PaymentMethod = TransactionDto.PaymentMethod,
                StudentYear = TransactionDto.StudentYear,
            };
        }
            public TransactionDto ToTransactionDto(Transaction transaction)
            {
                return new TransactionDto
                {
                Id = transaction.Id,
                Amount = transaction.Amount,
                LeftOver = transaction.LeftOver,
                Payments = transaction.Payments,
                UserId = transaction.UserId,
                StudentId = transaction.StudentId,
                PaymentMethod = transaction.PaymentMethod,
                StudentYear = transaction.StudentYear,
                };
            }

        }
}