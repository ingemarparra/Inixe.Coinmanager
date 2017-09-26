// <copyright file="FiatKeyValueJsonConverterUnitTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using Inixe.CoinManagement.CoinMarketCap.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class FiatKeyValueJsonConverterUnitTests
    /// </summary>
    /// <remarks>Unit tests for <see cref="FiatKeyValueJsonConverter"/> and <see cref="FiatKeyValueContractResolver"/></remarks>
    [TestClass]
    public class FiatKeyValueJsonConverterUnitTests
    {
        /// <summary>Tests the CanConvert Method for expected Behavior the right or compatible type</summary>
        /// <remarks>None</remarks>
        [TestMethod]
        public void CanConvertExpected()
        {
            var converter = new FiatKeyValueJsonConverter();
            var res = converter.CanConvert(typeof(Dictionary<FiatCurrency, decimal>));

            Assert.IsTrue(res);
        }

        /// <summary>Tests the CanConvert Method for expected Behavior using a wrong or incompatible type</summary>
        /// <remarks>None</remarks>
        [TestMethod]
        public void CanConvertWrongType()
        {
            var converter = new FiatKeyValueJsonConverter();
            var res = converter.CanConvert(typeof(decimal));

            Assert.IsFalse(res);
        }

        /// <summary>Tests the <see cref="FiatKeyValueContractResolver"/> in a deserialization operation</summary>
        /// <remarks>None</remarks>
        [TestMethod]
        public void DeserializeExpected()
        {
            const string SampleJson = "{\"currency_name\": 'Test', \"price_usd\": 22, \"price_eur\": 18, \"price_mxn\": 251}";
            const string ExpectedCurrencyName = "Test";
            const int ExpectedItemsCount = 3;

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new FiatKeyValueContractResolver();

            var res = Newtonsoft.Json.JsonConvert.DeserializeObject<FiatHolderMock>(SampleJson, settings);

            Assert.IsNotNull(res);
            Assert.AreEqual<string>(ExpectedCurrencyName, res.CurrencyName);
            Assert.AreEqual<int>(ExpectedItemsCount, res.Price.Count);
        }

        /// <summary>
        /// Class FiatHolderMock
        /// </summary>
        /// <remarks>This is a Stub Object</remarks>
        [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        private class FiatHolderMock
        {
            public string CurrencyName { get; set; }

            [JsonConverter(typeof(FiatKeyValueJsonConverter))]
            public Dictionary<FiatCurrency, decimal> Price { get; set; }
        }
    }
}
