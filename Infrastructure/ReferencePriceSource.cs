using RfqParser.Infrastructure;

namespace RfqParser.Domain
{
    public class ReferencePriceSource : IReferencePriceSource
    {
        //private readonly IReferencePriceSourceListener _referencePriceSourceListener;

        //public ReferencePriceSource(IReferencePriceSourceListener referencePriceSourceListener)
        //{
        //    _referencePriceSourceListener = referencePriceSourceListener;
        //}

        public void subscribe(IReferencePriceSourceListener listener)
        {
            return;
        }

        public double get(int securityId)
        {
            double refPrice = 0.0;

            return refPrice;
        }
    }
}