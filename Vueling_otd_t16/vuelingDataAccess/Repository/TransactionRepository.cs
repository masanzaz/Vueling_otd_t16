using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using vuelingDomain.Entities;
using vuelingDomain.Helper;
using vuelingDomain.Repository;
using System.Linq;


namespace vuelingDataAccess.Repository
{
    public class TransactionRepository : ConnectionService, ITransactionRepository
    {
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return GetTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySKU(string sku)
        {
            return GetTransactions(sku);
        }

        private IEnumerable<Transaction> GetTransactions(string sku = null)
        {

            List<Transaction> transactions = new List<Transaction>();
            var dataSet = GetData(URL, "transactions.json");
            PersistData.SaveFile(dataSet, "transactions.json");
            try
            {
                foreach (DataRow row in dataSet.Rows)
                {
                    if (string.IsNullOrEmpty(sku) || string.Equals(sku, Convert.ToString(row["sku"])))
                        transactions.Add(new Transaction(Convert.ToString(row["sku"]),
                            Convert.ToDecimal(row["amount"].ToString(), CultureInfo.InvariantCulture),
                            EnumHelpers.ParseEnum<Divisa>(Convert.ToString(row["currency"])))); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return transactions;
        }
    }
}