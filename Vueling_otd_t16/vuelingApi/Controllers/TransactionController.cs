using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoggerService.Interfaces;
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
        private readonly ILoggerManager _logger;
        public TransactionController(IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
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
                _logger.LogError(ex.Message);
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
                    _logger.LogWarn($"The sku {sku} doesn't exist.");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}