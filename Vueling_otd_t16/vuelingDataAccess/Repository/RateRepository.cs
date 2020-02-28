﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using vuelingDomain.Entities;
using vuelingDomain.Helper;
using vuelingDomain.Repository;

namespace vuelingDataAccess.Repository
{
    public class RateRepository : ConnectionService, IRateRepository
    {
        public IEnumerable<Rate> GetAllRates()
        {
            List<Rate> rates = new List<Rate>();
            var dataSet = GetData(URL, "rates.json");
            PersistData.Save(dataSet, "rates.json");
            foreach (DataRow row in dataSet.Rows)
            {
                rates.Add(new Rate(EnumHelpers.ParseEnum<Divisa>(Convert.ToString(row["from"])),
                    EnumHelpers.ParseEnum<Divisa>(Convert.ToString(row["to"])),
                    Convert.ToDecimal(row["rate"].ToString(), CultureInfo.InvariantCulture)));
            }
            return rates;
        }

    }
}
