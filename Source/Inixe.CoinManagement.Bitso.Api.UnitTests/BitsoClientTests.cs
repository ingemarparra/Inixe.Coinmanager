// -----------------------------------------------------------------------
// <copyright file="BitsoClientTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Inixe.CoinManagement.Bitso.Api;
    using System.Security;

    [TestClass]
    public class BitsoClientTests
    {
        public TestContext TestContext { get; set; }

        public string TestingServerUrl
        {
            get
            {
                const string DefaultTestingServerUrl = "https://api-dev.bitso.com/v3/";

                if (this.TestContext.Properties.Contains("ServerUrl"))
                {
                    return (string)this.TestContext.Properties["ServerUrl"];
                }

                return DefaultTestingServerUrl;
            }
        }

        public SecureString ApiSecret
        {
            get
            {
                if (this.TestContext.Properties.Contains("ApiSecret"))
                {
                    var secret = (string)this.TestContext.Properties["ApiSecret"];

                    SecureString retval = new SecureString();
                    for(int i=0; i<secret.Length;i++)
                    {
                        retval.AppendChar(secret[i]);
                    }

                    retval.MakeReadOnly();

                    return retval;
                }

                return null;
            }
        }

        public string ApiKey
        {
            get
            {
                if (this.TestContext.Properties.Contains("ApiKey"))
                {
                    return (string)this.TestContext.Properties["ApiKey"];
                }

                return string.Empty;
            }
        }

        [TestMethod]
        public void AvailableBooksExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAvailablePairs();

            Assert.AreNotEqual<int>(0, res.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(res[0].BookName));
        }

        [TestMethod]
        public void GetTickerExpected1()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetTicker("btc_mxn");

            Assert.IsNotNull(res);
            Assert.IsFalse(string.IsNullOrWhiteSpace(res.Book));

            Assert.AreNotEqual<decimal>(0M, res.Ask);
            Assert.AreNotEqual<decimal>(0M, res.Bid);
        }

        [TestMethod]
        public void GetAllTickersExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAllTickers();

            Assert.AreNotEqual<int>(0, res.Count);
        }

        [TestMethod]
        public void GetTradesExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetTrades("btc_mxn");

            Assert.AreNotEqual<int>(0, res.Count);
        }

        [TestMethod]
        public void GetOrderBookExpected1()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetOrderBook("btc_mxn");

            Assert.IsNotNull(res);

            res = client.GetOrderBook("btc_mxn", true);
            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.Asks.Count);
            Assert.AreNotEqual<int>(0, res.Bids.Count);
        }

        [TestMethod]
        public void GetAccountInfoExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetAccountInfo();
                    Assert.IsNotNull(res);
                }
                catch(BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        [TestMethod]
        public void GetPortfolioExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetPortfolio();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Balances.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        [TestMethod]
        public void GetFeeScheduleExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetFeeSchedule();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.TradeFees.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }
    }
}
