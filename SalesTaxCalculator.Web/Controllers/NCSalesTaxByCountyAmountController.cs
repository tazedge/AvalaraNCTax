using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SalesTaxCalculator.Domain.Interfaces;
using SalesTaxCalculator.Domain.Model;
using System.Web.Http;

namespace SalesTaxCalculator.Web.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class NCSalesTaxByCountyAmountController : ControllerBase
    {
        private readonly ILogger<NCSalesTaxByCountyAmountController> _logger;
        private readonly INCTaxRateRepository _rateRepository;
        private readonly IRoundTaxAmount _rounder;

        public NCSalesTaxByCountyAmountController(
            ILogger<NCSalesTaxByCountyAmountController> logger,
            INCTaxRateRepository rateRepository,
            IRoundTaxAmount rounder)
        {
            _logger = logger;
            _rateRepository = rateRepository;
            _rounder = rounder;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{county}/{amount}")]
        public IActionResult GetTaxForTransaction(string county, decimal amount)
        {
            var taxRate = _rateRepository.GetRateForCounty(county);

            if (taxRate == 0)
            {
                return NotFound();
            }

            var response = new TaxAmountResponse();

            response.County = county;
            response.SaleAmount = amount;
            response.TaxRate = taxRate;
            response.TaxAmount = _rounder.AmountToRound( amount * taxRate);
    
            return Ok(response); 
        }
    }
}
