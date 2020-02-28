using System;
using System.Collections.Generic;
using System.Text;

namespace vuelingDomain.Entities
{
    public class TransactionTotal
    {
        private decimal _total;
        private List<Transaction> _transactionList; 

        public decimal total { set => _total = value; get => _total; }
        public List<Transaction> transactionList
        {
            get
            {
                return this._transactionList;
            }
            set
            {
                if (value == null)
                {
                    _transactionList = new List<Transaction>();
                }
                this._transactionList = value;
            }
        }
    }
}
