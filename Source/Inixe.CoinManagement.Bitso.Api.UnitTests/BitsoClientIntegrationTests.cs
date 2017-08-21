// -----------------------------------------------------------------------
// <copyright file="BitsoClientIntegrationTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests
{
    using System.Linq;
    using System.Security;
    using Inixe.CoinManagement.Bitso.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The Bitso Client Integration Tests
    /// </summary>
    /// <remarks>Integration Tests</remarks>
    [TestClass]
    public class BitsoClientIntegrationTests
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
        [TestCategory("Integration Test")]
        [TestMethod]
        public void AvailableBooksExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAvailablePairs();

            Assert.AreNotEqual<int>(0, res.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(res[0].BookName));
            Assert.AreNotEqual<decimal>(0M, res[0].MaximumAmount);
            Assert.AreNotEqual<decimal>(0M, res[0].MaximumPrice);
            Assert.AreNotEqual<decimal>(0M, res[0].MaximumValue);
            Assert.AreNotEqual<decimal>(0M, res[0].MinimumAmount);
            Assert.AreNotEqual<decimal>(0M, res[0].MinimumPrice);
            Assert.AreNotEqual<decimal>(0M, res[0].MinimumValue);
        }

        /// <summary>Tests the GetTicker for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetTickerExpected1()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetTicker("btc_mxn");

            Assert.IsNotNull(res);
            Assert.IsFalse(string.IsNullOrWhiteSpace(res.BookName));

            Assert.AreNotEqual<decimal>(0M, res.Ask);
            Assert.AreNotEqual<decimal>(0M, res.Bid);
            Assert.AreNotEqual<decimal>(0M, res.VolumeWeightedAveragePrice);
            Assert.AreNotEqual<decimal>(0M, res.Low);
            Assert.AreNotEqual<decimal>(0M, res.High);
            Assert.AreNotEqual<decimal>(0M, res.Last);
            Assert.AreNotEqual<decimal>(0M, res.Volume);

            var diff = res.CreatedAt - default(System.DateTime);
            Assert.IsTrue(diff > System.TimeSpan.Zero);
        }

        /// <summary>Tests the GetAllTickers for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetAllTickersExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetAllTickers();

            Assert.AreNotEqual<int>(0, res.Count);
        }

        /// <summary>Tests the GetTrades for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetTradesExpected()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetTrades("btc_mxn");

            Assert.AreNotEqual<int>(0, res.Count);
            Assert.AreNotEqual<decimal>(0, res[0].Amount);
            Assert.IsFalse(string.IsNullOrEmpty(res[0].BookName));

            Assert.IsTrue(res[0].MakerSide != MarketSide.None);
            Assert.AreNotEqual<decimal>(0M, res[0].Price);
            Assert.AreNotEqual<decimal>(0M, res[0].Amount);
            Assert.AreNotEqual<long>(0, res[0].TradeId);

            var diff = res[0].CreatedAt - default(System.DateTime);
            Assert.IsTrue(diff > System.TimeSpan.Zero);
        }

        /// <summary>Tests the GetOrderBook for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetOrderBookExpected1()
        {
            var client = new BitsoClient(this.TestingServerUrl);

            var res = client.GetOrderBook("btc_mxn");

            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.Asks.Count);
            Assert.AreNotEqual<int>(0, res.Bids.Count);
            Assert.AreNotEqual<long>(0, res.Sequence);

            var diff = res.UpdatedAt - default(System.DateTime);
            Assert.IsTrue(diff > System.TimeSpan.Zero);

            Assert.AreNotEqual<decimal>(0M, res.Asks[0].Amount);
            Assert.AreNotEqual<decimal>(0M, res.Asks[0].Price);
            Assert.IsFalse(string.IsNullOrEmpty(res.Asks[0].OrderId));
            Assert.IsFalse(string.IsNullOrEmpty(res.Asks[0].BookName));

            const bool AggregateResults = true;

            res = client.GetOrderBook("btc_mxn", AggregateResults);

            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.Asks.Count);
            Assert.AreNotEqual<int>(0, res.Bids.Count);
            Assert.AreNotEqual<long>(0, res.Sequence);

            diff = res.UpdatedAt - default(System.DateTime);
            Assert.IsTrue(diff > System.TimeSpan.Zero);

            Assert.AreNotEqual<decimal>(0M, res.Asks[0].Amount);
            Assert.AreNotEqual<decimal>(0M, res.Asks[0].Price);
            Assert.IsTrue(string.IsNullOrEmpty(res.Asks[0].OrderId));
            Assert.IsFalse(string.IsNullOrEmpty(res.Asks[0].BookName));
        }

        /// <summary>Tests the GetAccountInfo for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetAccountInfoExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetAccountInfo();

                    Assert.IsNotNull(res);
                    Assert.IsFalse(string.IsNullOrEmpty(res.ClientId));
                    Assert.AreNotEqual<decimal>(0M, res.DailyLimit);
                    Assert.AreNotEqual<decimal>(0M, res.MonthlyLimit);
                    Assert.AreNotEqual<decimal>(0M, res.DailyRemaining);
                    Assert.IsFalse(string.IsNullOrEmpty(res.Email));
                    Assert.IsFalse(string.IsNullOrEmpty(res.FirstName));
                    Assert.IsFalse(string.IsNullOrEmpty(res.LastName));
                    Assert.AreNotEqual<AccountStatus>(AccountStatus.None, res.Status);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetPortfolio for expected behavior.</summary>
        [TestCategory("Integration Test")]
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
                    Assert.IsFalse(string.IsNullOrEmpty(res.Balances[0].Currency));
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetAccountFees for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetAccountFeesExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetAccountFees();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.TradeFees.Count);

                    Assert.IsFalse(string.IsNullOrEmpty(res.TradeFees[0].BookName));
                    Assert.AreNotEqual<decimal>(0M, res.TradeFees[0].Percent);
                    Assert.AreNotEqual<decimal>(0M, res.TradeFees[0].Value);
                    Assert.AreNotEqual<int>(0, res.WithdrawalFees.Count);
                    Assert.AreNotEqual<decimal>(0M, res.WithdrawalFees.First().Value);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetAllLedgerEntries for expected behavior.</summary>
        [TestCategory("Integration Test")]
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
                    Assert.AreNotEqual<int>(0, res[0].Balances.Count);
                    Assert.AreNotEqual<TransactionType>(TransactionType.None, res[0].Kind);
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Id));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Balances[0].Currency));

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
        [TestCategory("Integration Test")]
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
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Details.OrderId));
                    Assert.AreNotEqual<long>(0, res[0].Details.TradeId);

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
        [TestCategory("Integration Test")]
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
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Details.OrderId));
                    Assert.AreNotEqual<long>(0, res[0].Details.TradeId);

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
        [TestCategory("Integration Test")]
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
        [TestCategory("Integration Test")]
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

        /// <summary>Tests the GetWithdrawals for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetWithdrawalsExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetWithdrawals();

                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);
                    Assert.AreNotEqual<decimal>(0M, res[0].Amount);
                    Assert.AreNotEqual<TransferStatus>(TransferStatus.None, res[0].Status);
                    Assert.AreNotEqual<TransferMethod>(TransferMethod.None, res[0].Method);
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].MethodName));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Id));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Currency));

                    var diff = res[0].CreatedAt - default(System.DateTime);
                    Assert.IsTrue(diff > System.TimeSpan.Zero);

                    res = client.GetWithdrawals(2);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(2, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetFundings for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetFundingsExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetFundings();

                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);
                    Assert.AreNotEqual<decimal>(0M, res[0].Amount);
                    Assert.AreNotEqual<TransferStatus>(TransferStatus.None, res[0].Status);
                    Assert.AreNotEqual<TransferMethod>(TransferMethod.None, res[0].Method);
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].MethodName));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Id));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Currency));

                    var diff = res[0].CreatedAt - default(System.DateTime);
                    Assert.IsTrue(diff > System.TimeSpan.Zero);

                    res = client.GetFundings(2);
                    Assert.IsNotNull(res);
                    Assert.AreEqual<int>(2, res.Count);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetUserTradeByOrderId for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetUserTradeByOrderIdExpected()
        {
            var oid = (string)this.TestContext.Properties["OrderId"];

            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetUserTradeByOrderId(oid);

                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<decimal>(0M, res.Price);

                    var diff = res.CreatedAt - default(System.DateTime);
                    Assert.IsTrue(diff > System.TimeSpan.Zero);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetOpenTradeOrders for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetOpenTradeOrdersExpected()
        {
            const string BookName = "btc_mxn";

            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetOpenTradeOrders(BookName);

                    Assert.IsNotNull(res);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetTradeOrderByOrderId for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetTradeOrderByOrderIdExpected()
        {
            var oid = (string)this.TestContext.Properties["OrderId"];

            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetTradeOrderByOrderId(oid);

                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);
                    Assert.AreNotEqual<decimal>(0M, res[0].Price);

                    var diff = res[0].CreatedAt - default(System.DateTime);
                    Assert.IsTrue(diff > System.TimeSpan.Zero);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetUserTrades for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetUserTradesExpected()
        {
            const string BookName = "btc_mxn";

            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetUserTrades(BookName);

                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);
                    Assert.AreNotEqual<decimal>(0M, res[0].Price);

                    var diff = res[0].CreatedAt - default(System.DateTime);
                    Assert.IsTrue(diff > System.TimeSpan.Zero);
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetFundingDestinations for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetFundingDestinationsExpected()
        {
            const string CurrencyName = "mxn";

            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetFundingDestinations(CurrencyName);
                    Assert.IsNotNull(res);
                    Assert.IsFalse(string.IsNullOrEmpty(res.AccountIdentifierName));
                    Assert.IsFalse(string.IsNullOrEmpty(res.AccountIdentifier));
                }
                catch (BitsoException ex)
                {
                    this.TestContext.WriteLine(ex.Header);
                    throw;
                }
            }
        }

        /// <summary>Tests the GetBanksInfo for expected behavior.</summary>
        [TestCategory("Integration Test")]
        [TestMethod]
        public void GetBanksInfoExpected()
        {
            using (var client = new BitsoClient(this.TestingServerUrl, this.ApiKey, this.ApiSecret))
            {
                try
                {
                    var res = client.GetBanksInfo();
                    Assert.IsNotNull(res);
                    Assert.AreNotEqual<int>(0, res.Count);
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Name));
                    Assert.IsFalse(string.IsNullOrEmpty(res[0].Code));
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
