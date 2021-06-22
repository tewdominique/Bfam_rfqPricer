using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfqParser
{
    public class Rfq
    {
        public int SecurityId { get; set; }
        public bool Buy { get; set; }
        public int Quantity { get; set; }


        public Rfq(int securityId, bool buy, int quantity)
        {
            SecurityId = securityId;
            Buy = buy;
            Quantity = quantity;
        }
    }
}
