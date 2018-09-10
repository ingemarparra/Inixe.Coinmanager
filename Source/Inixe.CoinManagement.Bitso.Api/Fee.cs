// -----------------------------------------------------------------------
// <copyright file="Fee.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class Fee
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class Fee
    {
        /// <summary>Gets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; internal set; }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        [JsonProperty("taker_fee_decimal")]
        public decimal TakerValue { get; internal set; }

        /// <summary>Gets the percent.</summary>
        /// <value>The percent.</value>
        [JsonProperty("taker_fee_percent")]
        public decimal TakerPercent { get; internal set; }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        [JsonProperty("maker_fee_decimal")]
        public decimal MakerValue { get; internal set; }

        /// <summary>Gets the percent.</summary>
        /// <value>The percent.</value>
        [JsonProperty("maker_fee_percent")]
        public decimal MakerPercent { get; internal set; }
    }
}
