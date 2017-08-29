// -----------------------------------------------------------------------
// <copyright file="Ticker.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The Price Ticker
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class Ticker
    {
        /// <summary>Gets the book.</summary>
        /// <value>The book.</value>
        [JsonProperty("book")]
        public string BookName { get; internal set; }

        /// <summary>Gets the volume.</summary>
        /// <value>Last 24 hours volume.</value>
        public decimal Volume { get; internal set; }

        /// <summary>Gets the high.</summary>
        /// <value>Last 24 hours price high.</value>
        public decimal High { get; internal set; }

        /// <summary>Gets the last.</summary>
        /// <value>Last traded price.</value>
        public decimal Last { get; internal set; }

        /// <summary>Gets the low.</summary>
        /// <value>Last 24 hours price low.</value>
        public decimal Low { get; internal set; }

        /// <summary>Gets the vwap.</summary>
        /// <value>Last 24 hours volume weighted average price.</value>
        [JsonProperty("vwap")]
        public decimal VolumeWeightedAveragePrice { get; internal set; }

        /// <summary>Gets the ask.</summary>
        /// <value>Lowest sell order.</value>
        public decimal Ask { get; internal set; }

        /// <summary>Gets the bid.</summary>
        /// <value>Highest buy order.</value>
        public decimal Bid { get; internal set; }

        /// <summary>Gets the created at.</summary>
        /// <value>Timestamp at which the ticker was generated.</value>
        public DateTime CreatedAt { get; internal set; }
    }
}
