using System;
using System.Collections.Generic;
using System.Text;
using vuelingDataAccess.Repository;
using vuelingDomain.Entities;
using vuelingDomain.Repository;

namespace vuelingAplication.Services
{
    public class TransactionService
    {
        readonly ITransactionRepository _transactionRepository;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            var transactionList = _transactionRepository.GetAllTransactions();
            return transactionList;
        }
       
    }
}
