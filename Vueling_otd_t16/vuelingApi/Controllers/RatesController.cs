using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vuelingApi.Models;
using vuelingAplication.Services;
using vuelingDomain.Repository;

namespace vuelingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IMapper _mapper;
        public RatesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DtoRate>> GetAllRates()
        {
            try
            {
                var ratesList = new RateService().GetRates();
                var result = _mapper.Map<IEnumerable<DtoRate>>(ratesList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}