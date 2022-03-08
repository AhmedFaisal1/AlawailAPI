using System.Collections.Generic;
using System.Linq;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Models;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Services{
    public interface ITransactionServices{
        Transaction GetTransaction(int Id);
        List<TransactionDto> GetAll();
        Transaction CreateTransaction(TransactionDto transactionDto);
    }
    public class TransactionServices: ITransactionServices
    {
        private readonly ITransactionRepository _TransactionRepository;
        public TransactionServices(ITransactionRepository transactionRepository){
            _TransactionRepository = transactionRepository;
        }
        public Transaction GetTransaction(int id){
            return _TransactionRepository.GetTransaction(id);
            }
            public Transaction CreateTransaction(TransactionDto transactionDto){
                return _TransactionRepository.CreateTransaction(transactionDto);
            }
            public List<TransactionDto> GetAll()
        {
            return _TransactionRepository.GetAll().Select(_TransactionRepository.ToTransactionDto).ToList();
        }


    }
}