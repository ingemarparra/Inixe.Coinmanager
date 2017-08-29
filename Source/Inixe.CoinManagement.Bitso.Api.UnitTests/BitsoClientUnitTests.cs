// -----------------------------------------------------------------------
// <copyright file="BitsoClientUnitTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RestSharp;
    using RestSharp.Deserializers;

    /// <summary>
    /// Class BitsoClientUnitTests
    /// </summary>
    /// <remarks>None</remarks>
    [TestClass]
    public class BitsoClientUnitTests
    {
        private const string ServiceUrlMock = "http://foo.bar";
        private const string ApiKeyMock = "aaaaaaa";
        private const string ApiSecretMock = "0123456789abcdef1011121314151617";

        /// <summary>Gets or sets the test context.</summary>
        /// <value>The test context.</value>
        public TestContext TestContext { get; set; }

        /// <summary>Tests the PlaceOrder method for expected behavior.</summary>
        [TestMethod]
        [TestCategory("Unit Test")]
        public void PlaceOrderExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<TradeOrder>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<TradeOrder>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.PlaceOrderResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<TradeOrder>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

            var instruction = new TradeInstruction();

            instruction.Price = 1000;
            instruction.MajorCurrencyAmount = 1;
            instruction.OrderType = TradeOrderType.Limit;
            instruction.Side = MarketSide.Buy;
            instruction.BookName = "btc_mxn";

            var res = client.PlaceOrder(instruction);

            Assert.IsNotNull(res);
        }

        /// <summary>Tests the AvailableBooks for expected behavior.</summary>
        [TestCategory("Unit Test")]
        [TestMethod]
        public void AvailableBooksExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseCollection<CurrencyPair>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseCollection<CurrencyPair>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.AvailableBooksResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseCollection<CurrencyPair>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

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
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetTickerExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<Ticker>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<Ticker>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.TickerResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<Ticker>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

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

        /// <summary>Tests the GetTrades for expected behavior.</summary>
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetTradesExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseCollection<TradeInfo>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseCollection<TradeInfo>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.TradesInfoResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseCollection<TradeInfo>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

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
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetOrderBookExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<OrderBook>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<OrderBook>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                var aggregateParameter = request.Parameters.Find(x => x.Name == "aggregate");
                bool aggregate = aggregateParameter != null ? (bool)aggregateParameter.Value : false;

                responseMock.Object.Content = aggregate ? Properties.Resources.OrderBookResponse1 : Properties.Resources.OrderBookResponse2;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<OrderBook>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

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
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetAccountInfoExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<AccountInfo>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<AccountInfo>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.AccountStatusResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<AccountInfo>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

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

        /// <summary>Tests the GetPortfolio for expected behavior.</summary>
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetPortfolioExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<Portfolio>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<Portfolio>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.PortfolioResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<Portfolio>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

            var res = client.GetPortfolio();

            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.Balances.Count);
            Assert.IsFalse(string.IsNullOrEmpty(res.Balances[0].Currency));
        }

        /// <summary>Tests the GetAccountFees for expected behavior.</summary>
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetAccountFeesExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseSingle<AccountFees>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<AccountFees>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.AccountFeesResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseSingle<AccountFees>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);

            var res = client.GetAccountFees();
            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.TradeFees.Count);

            Assert.IsFalse(string.IsNullOrEmpty(res.TradeFees[0].BookName));
            Assert.AreNotEqual<decimal>(0M, res.TradeFees[0].Percent);
            Assert.AreNotEqual<decimal>(0M, res.TradeFees[0].Value);
            Assert.AreNotEqual<int>(0, res.WithdrawalFees.Count);
            Assert.AreNotEqual<decimal>(0M, res.WithdrawalFees.First().Value);
        }

        /// <summary>Tests the GetAllLedgerEntries for expected behavior.</summary>
        [TestCategory("Unit Test")]
        [TestMethod]
        public void GetAllLedgerEntriesExpected()
        {
            IDeserializer deserializer = null;

            var restMock = new Mock<IRestClient>(MockBehavior.Strict);

            restMock.SetupAllProperties();
            restMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((ct, d) => deserializer = d);

            restMock.Setup(x => x.Execute<ResponseCollection<LedgerEntryBase>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<ResponseCollection<LedgerEntryBase>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.LedgerResponse;
                responseMock.Object.Request = request;
                responseMock.Object.Data = deserializer.Deserialize<ResponseCollection<LedgerEntryBase>>(responseMock.Object);

                return responseMock.Object;
            });

            var client = new BitsoClient(restMock.Object, ServiceUrlMock, ApiKeyMock, ApiSecretMock);
            var res = client.GetAllLedgerEntries();

            Assert.IsNotNull(res);
            Assert.AreNotEqual<int>(0, res.Count);
            Assert.AreNotEqual<int>(0, res[0].Balances.Count);
            Assert.AreNotEqual<TransactionType>(TransactionType.None, res[0].Kind);
            Assert.IsFalse(string.IsNullOrEmpty(res[0].Id));
            Assert.IsFalse(string.IsNullOrEmpty(res[0].Balances[0].Currency));

            res = client.GetAllLedgerEntries(string.Empty, SortDirection.Ascending, 7);
            Assert.IsNotNull(res);
            Assert.AreEqual<int>(7, res.Count);
        }
    }
}
