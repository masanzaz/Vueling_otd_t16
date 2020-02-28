using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vuelingDataAccess.Repository;
using vuelingDomain.Entities;
using vuelingDomain.Helper;
using vuelingDomain.Repository;

namespace vuelingAplication.Services
{
    public class TransactionService
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IRateRepository _rateRepository;

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            _rateRepository = new RateRepository();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            var transactionList = _transactionRepository.GetAllTransactions();
            return transactionList;
        }
        public TransactionTotal GetTransactionsBySKU(string sku)
        {
            TransactionTotal transactionTotal = new TransactionTotal();
            var transactionList = _transactionRepository.GetTransactionsBySKU(sku);
            var rateList = _rateRepository.GetAllRates();
            try
            {
                foreach (var transaction in transactionList)
                {
                    while (transaction.currency != Divisa.EUR)
                    {
                        var rate = rateList.Any(x => x.from == transaction.currency && x.to == Divisa.EUR) ? rateList.FirstOrDefault(x => x.from == transaction.currency && x.to == Divisa.EUR) : rateList.FirstOrDefault(x => x.from == transaction.currency);

                        transaction.currency = rate.to;
                        transaction.amount = RoundNumber.RoundHalfToEven(transaction.amount * rate.rate);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            transactionTotal.transactionList = transactionList.ToList();
            transactionTotal.total = transactionList.Select(x => x.amount)
                                                     .DefaultIfEmpty(0)
                                                     .Sum();
            return transactionTotal;
        }

    }
}
