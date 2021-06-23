using RfqParser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfqParser.Domain
{
    public class RfqPricerEngine
    {

        private IQuoteCalculationEngine _quoteCalculationEngine;
        private IReferencePriceSource _referencePriceSource;
        //private QuoteCalculationEngine _quoteCalculationEngine;

        public RfqPricerEngine(IQuoteCalculationEngine quoteCalculationEngine,IReferencePriceSource referencePriceSource)
        {
            _quoteCalculationEngine = quoteCalculationEngine;
            _referencePriceSource = referencePriceSource;
        }

        public async Task<double> PricingOrchestrationAsync(int securityId, bool buy, int quantity)
        {

            double refPrice = _referencePriceSource.get(securityId);
            //make the calculation async
            var quotedPrice = await _quoteCalculationEngine.calculateQuotePrice(securityId, refPrice, buy, quantity);

            return quotedPrice;
        }

        public async Task<double> PricingOrchestrationAsync(Rfq rfq)
        {
            var quotedPrice = await PricingOrchestrationAsync(rfq.SecurityId, rfq.Buy, rfq.Quantity);

            return quotedPrice;
        }
    }
}
