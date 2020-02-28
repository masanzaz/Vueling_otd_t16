using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vuelingApi.Models;
using vuelingAplication.Services;

namespace vuelingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        public TransactionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DtoTransaction>> GetAllTransactions()
        {
            try
            {
                var transactionsList = new TransactionService().GetAllTransactions();
                var result = _mapper.Map<IEnumerable<DtoTransaction>>(transactionsList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{sku}")]
        public ActionResult<DtoTransactionTotal> GetTransactionsBySKU(string sku)
        {
            try
            {
                var transactionsList = new TransactionService().GetTransactionsBySKU(sku);
                var result = _mapper.Map<DtoTransactionTotal>(transactionsList);
                if (!result.transactionList.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}