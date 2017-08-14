// -----------------------------------------------------------------------
// <copyright file="Trade.cs" company="Inixe">
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
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The Makers Side
    /// </summary>
    /// <remarks>None</remarks>
    public enum MarketSide
    {
        /// <summary>The buy</summary>
        Buy,

        /// <summary>The sell</summary>
        Sell,
    }

    /// <summary>
    /// Class Trade
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Trade
    {
        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the maker side.</summary>
        /// <value>The maker side.</value>
        [JsonProperty("maker_side", ItemConverterType = typeof(StringEnumConverter))]
        public MarketSide MakerSide { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }

        /// <summary>Gets or sets the trade identifier.</summary>
        /// <value>The trade identifier.</value>
        [JsonProperty("tid")]
        public long TradeId { get; set; }
    }
}
