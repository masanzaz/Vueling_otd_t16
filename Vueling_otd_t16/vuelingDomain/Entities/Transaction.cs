using System;
using System.Collections.Generic;
using System.Text;

namespace vuelingDomain.Entities
{
    public class Transaction
    {
        private string _sku;
        private decimal _amount;
        private Divisa _currency;

        public Transaction(string sku, decimal amount, Divisa currency)
        {
            _sku = sku;
            _amount = amount;
            _currency = currency;
        }
        public string sku { get => _sku; }
        public decimal amount { set => _amount = value; get => _amount; }
        public Divisa currency { set => _currency = value; get => _currency; }
    }
}
