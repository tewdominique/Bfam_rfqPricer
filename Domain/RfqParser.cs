using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RfqParser
{
    public class RfqParser
    {
        private Regex _rx;
        public RfqParser()
        {
            //security and quantity limited to 9 digit
            //way is case sensitive
            _rx = new Regex(@"^\d{1,9} (BUY|SELL) \d{1,9}$");
        }

        public bool IsValid(string rfqLine) => _rx.IsMatch(rfqLine);

        public Rfq rfqBuilder(string rfqLine)
        {
            int securityId = 0;
            bool buy = true;
            int quantity = 100;
            
            //if rfqLine is Valid we extract Rfq Variables
            if (IsValid(rfqLine))
            {
                var rfqArgs = rfqLine.Split();
                securityId = Int32.Parse(rfqArgs[0]);
                buy = (rfqArgs[1] == "BUY");
                quantity = Int32.Parse(rfqArgs[2]);
            }

            Rfq rfq = new Rfq(securityId,buy,quantity);

            return rfq;
        }

    }
}
