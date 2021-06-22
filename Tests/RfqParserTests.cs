using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfqParser
{
    [TestFixture]
    public class RfqParserTests
    {
        //string rfq1 = "123 BUY 100";
        private RfqParser _parser = new RfqParser();

        //[SetUp]
        //public void testInit()
        //{
        //    _parser = new RfqParser();
        //}

        [Test]
        public void isRfqLineValid2()
        {
            string rfq = "123 BUY 100";
            var valid = _parser.IsValid(rfq);
            Assert.That(valid,Is.EqualTo(true));
        }

        [Test]
        [TestCase("123 BUY 100", true)]
        [TestCase("123 SELL 100", true)]
        [TestCase("123456789 SELL 100", true)]
        [TestCase("1234567890 SELL 100", false)]
        [TestCase("", false)]
        [TestCase(" SEELL 100", false)]
        [TestCase("123  BUY 100", false)]
        [TestCase("123 SEELL 100", false)]
        [TestCase("123 SEELL 100 26", false)]
        public void isRfqLineValidTest(string rfqLine, bool expectedResult)
        {
            var valid = _parser.IsValid(rfqLine);
            Assert.AreEqual(valid, expectedResult);
        }


        [Test]
        [TestCase("123 BUY 50", 123, true, 50)]
        [TestCase("500 SELL 200", 500, false, 200)]
        public void RfqBuilderTest(string rfqLine, int expectedSecurityId, bool expectedResult, int expectedQuantity)
        {
            Rfq rfq = _parser.rfqBuilder(rfqLine);
            Assert.AreEqual(rfq.SecurityId, expectedSecurityId);
            Assert.AreEqual(rfq.Buy, expectedResult);
            Assert.AreEqual(rfq.Quantity, expectedQuantity);
        }
    }
}
