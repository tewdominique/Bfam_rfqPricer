using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfqParser.Infrastructure
{
    public interface IQuoteCalculationEngine 
    {
        Task<double> calculateQuotePrice(int securityId, double referencePrice, bool buy, int quantity);
    }
}
