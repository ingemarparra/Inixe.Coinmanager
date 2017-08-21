// -----------------------------------------------------------------------
// <copyright file="TradeInfo.cs" company="Inixe">
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
        /// <summary>The none value.</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>The buy</summary>
        Buy,

        /// <summary>The sell</summary>
        Sell,
    }

    /// <summary>
    /// Class Trade
    /// </summary>
    /// <remarks>Holds the Public trade information. This is used for market data</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TradeInfo : ITrade
    {
        /// <inheritdoc/>
        public string BookName { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <inheritdoc/>
        [JsonProperty("maker_side", ItemConverterType = typeof(StringEnumConverter))]
        public MarketSide MakerSide { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public long TradeId { get; set; }
    }
}
