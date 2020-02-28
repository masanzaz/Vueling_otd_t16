using System;
using System.Collections.Generic;
using System.Text;
using vuelingDomain.Entities;

namespace vuelingDomain.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
    }
}
