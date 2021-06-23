using Microsoft.AspNetCore.Mvc;
using RfqParser.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfqParser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RfqPricerController : ControllerBase
    {
        private RfqParser _rfqParser;
        private RfqPricerEngine _rfqPricerEngine;

        public RfqPricerController(RfqParser rfqParser, RfqPricerEngine rfqPricerEngine)
        {
            _rfqParser = rfqParser;
            _rfqPricerEngine = rfqPricerEngine;
        }


        [HttpPost]
        public async Task<IActionResult> ComputePrice(string rfqLine)
        {
            double res = 0;

            if (!_rfqParser.IsValid(rfqLine))
            {
                return BadRequest("Rfq Format should: SecurityId (BUY|SELL) Quantity") ;
            }
            Rfq rfq = _rfqParser.rfqBuilder(rfqLine);
            res = await _rfqPricerEngine.PricingOrchestrationAsync(rfq);

            return Ok(res);

        }

        //[HttpGet]
        //public IEnumerable<Rfq> Get()
        //{
        //    var rng = new Random();
        //    List<string> buySell;

        //    return Enumerable.Range(1, 5).Select(index => new Rfq
        //    {
        //        SecurityId = rng.Next(1,1000),
        //        Buy = rng.NextDouble() >= 0.5,
        //        Quantity = rng.Next(1, 1000)
        //    })
        //    .ToArray();
        //}


        [HttpGet]
        [Route("price")]
        public IActionResult GetPrice()
        {
            var result = "RFQ: 0700 BUY 500"
                + "\n"
                + "Priced Quoted: 123456";

            return Ok(result);
        }

    }
}
