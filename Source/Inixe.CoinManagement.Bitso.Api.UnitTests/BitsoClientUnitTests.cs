// -----------------------------------------------------------------------
// <copyright file="BitsoClientUnitTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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

            restMock.Setup(x => x.Execute<ResponseSingle<TradeOrder>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(y =>
            {
                var responseMock = new Mock<IRestResponse<ResponseSingle<TradeOrder>>>(MockBehavior.Strict);
                responseMock.SetupAllProperties();

                responseMock.Object.Content = Properties.Resources.PlaceOrderResponse;
                responseMock.Object.Request = y;
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
    }
}
