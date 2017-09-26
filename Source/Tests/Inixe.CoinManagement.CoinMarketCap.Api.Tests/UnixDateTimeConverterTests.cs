// <copyright file="UnixDateTimeConverterTests.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>Class UnixDateTimeConverterTests</summary>
    /// <remarks>Unit tests for <see cref="UnixDateTimeConverter"/> class</remarks>
    [TestClass]
    public class UnixDateTimeConverterTests
    {
        /// <summary>Tests the CanConvert Method for expected Behavior the right or compatible type</summary>
        /// <remarks>None</remarks>
        [TestMethod]
        public void CanConvertExpected()
        {
            var converter = new UnixDateTimeConverter();
            var res = converter.CanConvert(typeof(DateTime));

            Assert.IsTrue(res);
        }

        /// <summary>Tests the CanConvert Method for expected Behavior using a wrong or incompatible type</summary>
        /// <remarks>None</remarks>
        [TestMethod]
        public void CanConvertWrongType()
        {
            var converter = new UnixDateTimeConverter();
            var res = converter.CanConvert(typeof(decimal));

            Assert.IsFalse(res);
        }
    }
}
