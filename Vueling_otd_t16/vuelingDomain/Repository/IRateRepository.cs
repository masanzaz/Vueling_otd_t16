using System;
using System.Collections.Generic;
using System.Text;
using vuelingDomain.Entities;

namespace vuelingDomain.Repository
{
    public interface IRateRepository
    {
        IEnumerable<Rate> GetRates();
    }
}
