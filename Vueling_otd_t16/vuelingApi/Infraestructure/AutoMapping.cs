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
            CreateMap<Transaction, DtoTransaction>();
            CreateMap<TransactionTotal, DtoTransactionTotal>()
             .ForMember(
                dest => dest.transactionList,
                opt => opt.MapFrom(src => src.transactionList));
        }
    }
}
