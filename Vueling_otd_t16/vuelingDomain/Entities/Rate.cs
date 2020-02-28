using System;
using System.Collections.Generic;
using System.Text;

namespace vuelingDomain.Entities
{
    public class Rate
    {
        private Divisa _from;
        private Divisa _to;
        private decimal _rate;

        public Rate(Divisa from, Divisa to, decimal rate)
        {
            this._from = from;
            this._to = to;
            this._rate = rate;
        }

        public Divisa from { get => _from; }
        public Divisa to { get => _to; }
        public decimal rate { get => _rate; }

    }
}
