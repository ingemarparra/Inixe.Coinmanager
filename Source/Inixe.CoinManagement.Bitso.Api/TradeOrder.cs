// -----------------------------------------------------------------------
// <copyright file="TradeOrder.cs" company="Inixe">
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
    /// Enum TradeOrderType
    /// </summary>
    /// <remarks>Various Order Types</remarks>
    public enum TradeOrderType
    {
        /// <summary>The none value.</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>The limit order</summary>
        Limit,

        /// <summary>The market order</summary>
        Market,
    }

    /// <summary>
    /// Class TradeOrder
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TradeOrder
    {
        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the original amount.</summary>
        /// <value>The original amount.</value>
        public decimal OriginalAmount { get; set; }

        /// <summary>Gets or sets the unfilled amount.</summary>
        /// <value>The unfilled amount.</value>
        public decimal UnfilledAmount { get; set; }

        /// <summary>Gets or sets the original value.</summary>
        /// <value>The original value.</value>
        public decimal OriginalValue { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the updated at.</summary>
        /// <value>The updated at.</value>
        public DateTime UpdatedAt { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonProperty("oid")]
        public string Id { get; set; }

        /// <summary>Gets or sets the side.</summary>
        /// <value>The side.</value>
        [JsonProperty("side", ItemConverterType = typeof(StringEnumConverter))]
        public MarketSide Side { get; set; }

        /// <summary>Gets or sets the type of the order.</summary>
        /// <value>The type of the order.</value>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter))]
        public TradeOrderType OrderType { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public string Status { get; set; }
    }
}
