using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vuelingDomain.Entities;

namespace vuelingApi.Models
{
    [Serializable]
    public class DtoRate
    {
        private Divisa _from;
        private Divisa _to;
        private decimal _rate;
        public string from { get => _from.ToString(); }
        public string to { get => _to.ToString(); }
        public decimal rate { get => _rate; }

        public DtoRate(Divisa from, Divisa to, decimal rate)
        {
            this._from = from;
            this._to = to;
            this._rate = rate;
        }
    }
}