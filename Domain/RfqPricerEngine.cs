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

        public double PricingOrchestration(int securityId, bool buy, int quantity)
        {

            double refPrice = _referencePriceSource.get(securityId);
            //make the calculation async
            double quotedPrice = _quoteCalculationEngine.calculateQuotePrice(securityId, refPrice, buy, quantity);

            return quotedPrice;
        }

        public double PricingOrchestration(Rfq rfq)
        {
            return PricingOrchestration(rfq.SecurityId, rfq.Buy, rfq.Quantity);
        }
    }
}
