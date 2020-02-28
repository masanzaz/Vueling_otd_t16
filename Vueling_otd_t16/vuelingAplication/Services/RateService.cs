using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using vuelingDataAccess.Repository;
using vuelingDomain.Entities;
using vuelingDomain.Repository;

namespace vuelingAplication.Services
{
    public class RateService
    {
        readonly IRateRepository _rateRepository;
        public RateService()
        {
            _rateRepository = new RateRepository();
        }
        public IEnumerable<Rate> GetAllRates()
        {
            return _rateRepository.GetAllRates();
        }


    }
}