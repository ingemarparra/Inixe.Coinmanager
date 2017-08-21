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
    /// Class Trade
    /// </summary>
    /// <remarks>Holds User Trades Data</remarks>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ITrade" />
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Trade : ITrade
    {
        /// <inheritdoc/>
        public string BookName { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        [JsonProperty("side", ItemConverterType = typeof(StringEnumConverter))]
        public MarketSide MakerSide { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public long TradeId { get; set; }

        /// <summary>Gets or sets the order identifier.</summary>
        /// <value>The order identifier.</value>
        [JsonProperty("oid", ItemConverterType = typeof(StringEnumConverter))]
        public string OrderId { get; set; }

        /// <summary>Gets or sets the fees currency name.</summary>
        /// <value>The fees currency.</value>
        public string FeesCurrency { get; set; }

        /// <summary>Gets or sets the fees amount.</summary>
        /// <value>The fees amount.</value>
        public decimal FeesAmount { get; set; }

        /// <summary>Gets or sets the minor currency amount.</summary>
        /// <value>The minor.</value>
        public decimal Minor { get; set; }

        /// <summary>Gets or sets the major currency amount.</summary>
        /// <value>The major.</value>
        public decimal Major { get; set; }
    }
}
