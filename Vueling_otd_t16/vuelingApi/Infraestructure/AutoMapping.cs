using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vuelingApi.Models;
using vuelingDomain.Entities;

namespace vuelingApi.Infraestructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Rate, DtoRate>();
        }
    }
}
