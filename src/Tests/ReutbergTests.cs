using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NUnit.Framework;
using Reutberg;

namespace Tests
{
    [TestFixture]
    public class ReutbergTests
    {
        [Test]
        public void InitialDoesNotThrowUnexectedForManyTickers()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100;
            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    reutberg.GetQuote(Guid.NewGuid().ToString());
                }
                catch (QuoteException)
                {
                }
            }

            Assert.Pass("All ok");
        }

        [Test]
        public void InitialThrowsQuoteExceptionSometimes()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100;
            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    reutberg.GetQuote(Guid.NewGuid().ToString());
                }
                catch (QuoteException)
                {
                    Assert.Pass("QuoteException thrown");
                }
            }

            Assert.Fail("Should thrown QuoteException at least once");
        }
        [Test]
        public void RepeatedDoesNotThrowUnexectedForManyTickers()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100;
            string ticker = Guid.NewGuid().ToString();

            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    reutberg.GetQuote(ticker);
                }
                catch (QuoteException)
                {
                }
            }

            Assert.Pass("All ok");
        }

        [Test]
        public void RepeatedThrowsQuoteExceptionSometimes()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100;
            string ticker = Guid.NewGuid().ToString();

            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    reutberg.GetQuote(ticker);
                }
                catch (QuoteException)
                {
                    Assert.Pass("QuoteException thrown");
                }
            }

            Assert.Fail("Should thrown QuoteException at least once");
        }

        [Test]
        public void WatchSomeTicks()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100;
            string ticker = Guid.NewGuid().ToString();

            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    var quote = reutberg.GetQuote(ticker);
                    Debug.WriteLine(quote);
                }
                catch (QuoteException)
                {
                    Debug.WriteLine("QuoteException");
                }
            }
        }

        [Test]
        public void BuyReturnsPositive()
        {
            var reutberg = new ReutbergService();
            string ticker = Guid.NewGuid().ToString();
            var result = reutberg.Buy(ticker, 100);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void SellReturnsNegative()
        {
            var reutberg = new ReutbergService();
            string ticker = Guid.NewGuid().ToString();
            var result = reutberg.Sell(ticker, 100);

            Assert.That(result, Is.LessThan(0));
        }

        [Test]
        public void Works()
        {
            var reutberg = new ReutbergService();
            int repeatCount = 100000;
            string ticker = Guid.NewGuid().ToString();
            decimal? targetPrice = null;

            for (int i = 0; i < repeatCount; ++i)
            {
                try
                {
                    var quote = reutberg.GetQuote(ticker);
                    if (!targetPrice.HasValue)
                    {
                        targetPrice = quote * 0.9m;
                        continue;
                    }
                    if (quote <= targetPrice)
                    {
                        Assert.Pass("Passed after {0} quotes", i);
                    }
                }
                catch (QuoteException)
                {
                }
            }

            Assert.Fail("Did not reach termination");
        }
    }
}
