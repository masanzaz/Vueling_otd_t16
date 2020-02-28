using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vuelingDomain.Entities;

namespace vuelingApi.Models
{
    public class DtoTransactionTotal
    {
        private decimal _total;
        private List<DtoTransaction> _transactionList;

        public decimal total { set => _total = value; get => _total; }
        public List<DtoTransaction> transactionList
        {
            get
            {
                return this._transactionList;
            }
            set
            {
                if (value == null)
                {
                    _transactionList = new List<DtoTransaction>();
                }
                this._transactionList = value;
            }
        }
    }
}
