// <copyright file="CoinMarketCapClientUnitTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using Inixe.CoinManagement.CoinMarketCap.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RestSharp;
    using RestSharp.Deserializers;

    /// <summary>
    /// Class CoinMarketCapClientUnitTests
    /// </summary>
    /// <remarks>Unit Tests for <see cref="CoinMarketCapClient"/> class.</remarks>
    [TestClass]
    public class CoinMarketCapClientUnitTests
    {
        /// <summary>Tests the GetTicker for expected behavior.</summary>
        /// <remarks>Uses Moq. to simulate an actual call to the WebAPI</remarks>
        [TestMethod]
        public void GetTickerExpected()
        {
            var httpClientMock = new Mock<IRestClient>();
            IDeserializer deserializer = null;

            httpClientMock.Setup(x => x.AddHandler("application/json", It.IsAny<IDeserializer>())).Callback<string, IDeserializer>((c, d) => deserializer = d);
            httpClientMock.SetupAllProperties();

            httpClientMock.Setup(x => x.Execute<List<Ticker>>(It.IsAny<IRestRequest>())).Returns<IRestRequest>(request =>
            {
                var responseMock = new Mock<IRestResponse<List<Ticker>>>();
                responseMock.Setup(x => x.Content).Returns(Properties.Resources.CoinMarketCap_Sample);
                responseMock.Setup(x => x.Request).Returns(request);
                responseMock.Setup(x => x.ContentType).Returns("application/json");
                responseMock.Setup(x => x.Data).Returns(() => deserializer.Deserialize<List<Ticker>>(responseMock.Object));

                return responseMock.Object;
            });

            var client = new CoinMarketCapClient(httpClientMock.Object, 3);

            var res = client.GetTicker();

            Assert.IsNotNull(res);

            res = client.GetTicker(FiatCurrency.EUR);

            Assert.IsNotNull(res);

            res = client.GetTicker(4, FiatCurrency.EUR);

            Assert.IsNotNull(res);
        }
    }
}
