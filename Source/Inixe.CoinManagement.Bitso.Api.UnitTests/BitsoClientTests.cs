// -----------------------------------------------------------------------
// <copyright file="BitsoClientTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests
{
    using System.Security;
    using Inixe.CoinManagement.Bitso.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Bitso Client Integration Tests
    /// </summary>
    /// <remarks>Integration Tests</remarks>
    [TestClass]
    public class BitsoClientTests
    {
        /// <summary>Gets or sets the test context.</summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }

        /// <summary>Gets the testing server URL.</summary>
        /// <value>The testing server URL.</value>
        /// <remarks>The value is read from the test configuration settings</remarks>
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

        /// <summary>Gets the API secret.</summary>
        /// <value>The API secret.</value>
        /// <remarks>The value is read from the test configuration settings</remarks>
        public SecureString ApiSecret
        {
            get
            {
                if (this.TestContext.Properties.Contains("ApiSecret"))
                {
                    var secret = (string)this.TestContext.Properties["ApiSecret"];

                    SecureString retval = new SecureString();
                    for (int i = 0; i < secret.Length; i++)
                    {
                        retval.AppendChar(secret[i]);
                    }

                    retval.MakeReadOnly();

                    return retval;
                }

                return null;
            }
        }

        /// <summary>Gets the API key.</summary>
        /// <value>The API key.</value>
        /// <remarks>The value is read from the test configuration settings</remarks>
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

        /// <summary>Tests the AvailableBooks for expected behavior.</summary>
        [TestMethod]
        public void AvailableBooksExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAvailablePairs();

            Assert.AreNotEqual<int>(0, res.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(res[0].BookName));
        }

        /// <summary>Tests the GetTicker for expected behavior.</summary>
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

        /// <summary>Tests the GetAllTickers for expected behavior.</summary>
        [TestMethod]
        public void GetAllTickersExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAllTickers();

            Assert.AreNotEqual<int>(0, res.Count);
        }

        /// <summary>Tests the GetTrades for expected behavior.</summary>
        [TestMethod]
        public void GetTradesExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetTrades("btc_mxn");

            Assert.AreNotEqual<int>(0, res.Count);
        }

        /// <summary>Tests the GetOrderBook for expected behavior.</summary>
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

        /// <summary>Tests the GetAccountInfo for expected behavior.</summary>
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
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetPortfolio for expected behavior.</summary>
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

        /// <summary>Tests the GetFeeSchedule for expected behavior.</summary>
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

        /// <summary>Tests the GetAllLedgerEntries for expected behavior.</summary>
        [TestMethod]
        public void GetAllLedgerEntriesExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetAllLedgerEntries();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);

                    res = client.GetAllLedgerEntries(string.Empty, SortDirection.Ascending, 5);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(5, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetLedgerTrade for expected behavior.</summary>
        [TestMethod]
        public void GetLedgerTradeExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetLedgerTrade();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);

                    res = client.GetLedgerTrade(string.Empty, SortDirection.Ascending, 5);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(5, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetLedgerFee for expected behavior.</summary>
        [TestMethod]
        public void GetLedgerFeeExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetLedgerFee();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);

                    res = client.GetLedgerFee(string.Empty, SortDirection.Ascending, 5);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(5, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetLedgerWithdrawal for expected behavior.</summary>
        [TestMethod]
        public void GetLedgerWithdrawalExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetLedgerWithdrawal();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);

                    res = client.GetLedgerWithdrawal(string.Empty, SortDirection.Ascending, 5);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(5, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetLedgerFunding for expected behavior.</summary>
        [TestMethod]
        public void GetLedgerFundingExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetLedgerFunding();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);

                    res = client.GetLedgerFunding(string.Empty, SortDirection.Ascending, 5);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(5, res.Count);
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
