// -----------------------------------------------------------------------
// <copyright file="JsonSerializerTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests
{
    using System;
    using Inixe.CoinManagement.Bitso.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void JsonSerializerExpected()
        {
            const string rawOrderBook = "{\"success\":true,\"payload\":{\"updated_at\":\"2017-08-01T23:51:16+00:00\",\"bids\":[{\"book\":\"btc_mxn\",\"price\":\"46872.40\",\"amount\":\"0.04059332\",\"oid\":\"vJk8drn4fRXQQ71l\"}],\"asks\":[{\"book\":\"btc_mxn\",\"price\":\"47449.75\",\"amount\":\"0.23604892\",\"oid\":\"kQQXOXvQ3gRVV1Ot\"}],\"sequence\":\"18829290\"}}";
            var serializer = new JsonSerializer();

            var res = serializer.Deserialize<OrderBook>(rawOrderBook);
            Assert.IsNotNull(res);
        }
    }
}
