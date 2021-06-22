using RfqParser.Infrastructure;
using System.Threading.Tasks;

namespace RfqParser.Domain
{
    public class QuoteCalculationEngine : IQuoteCalculationEngine
    {

        public double calculateQuotePrice(int securityId, double referencePrice, bool buy, int quantity)
        {
            double quotedPrice = 0;

            return quotedPrice;
        }
    }
}