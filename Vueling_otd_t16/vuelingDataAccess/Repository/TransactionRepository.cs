using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using vuelingDataAccess.Services;
using vuelingDomain.Entities;
using vuelingDomain.Helper;
using vuelingDomain.Repository;

namespace vuelingDataAccess.Repository
{
    public class TransactionRepository : ConnectionService, ITransactionRepository
    {
        public IEnumerable<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            string path = $"{URL}transactions.json";

            var dataSet = GetData(path);

            foreach (DataRow row in dataSet.Rows)
            {
                transactions.Add(new Transaction(Convert.ToString(row["sku"]),
                    Convert.ToDecimal(row["amount"].ToString(), CultureInfo.InvariantCulture),
                    EnumHelpers.ParseEnum<Divisa>(Convert.ToString(row["currency"])))); ;

            }
            return transactions;
        }
    }
}