using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vuelingDomain.Entities;

namespace vuelingApi.Models
{
    [Serializable]
    public class DtoTransaction
    {
        private string _sku;
        private decimal _amount;
        private Divisa _currency;
        public string sku { get => _sku; }
        public decimal amount { get => _amount; }
        public string currency { get => _currency.ToString(); }

        public DtoTransaction(string sku, decimal amount, Divisa currency)
        {
            this._sku = sku;
            this._amount = amount;
            this._currency = currency;
        }
    }
}