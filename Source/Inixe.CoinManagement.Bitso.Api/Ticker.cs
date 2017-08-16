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
    public class Ticker
    {
        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>Last 24 hours volume.</value>
        public decimal Volume { get; set; }

        /// <summary>Gets or sets the high.</summary>
        /// <value>Last 24 hours price high.</value>
        public decimal High { get; set; }

        /// <summary>Gets or sets the last.</summary>
        /// <value>Last traded price.</value>
        public decimal Last { get; set; }

        /// <summary>Gets or sets the low.</summary>
        /// <value>Last 24 hours price low.</value>
        public decimal Low { get; set; }

        /// <summary>Gets or sets the vwap.</summary>
        /// <value>Last 24 hours volume weighted average price.</value>
        [JsonProperty("vwap")]
        public decimal VolumeWeightedAveragePrice { get; set; }

        /// <summary>Gets or sets the ask.</summary>
        /// <value>Lowest sell order.</value>
        public decimal Ask { get; set; }

        /// <summary>Gets or sets the bid.</summary>
        /// <value>Highest buy order.</value>
        public decimal Bid { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>Timestamp at which the ticker was generated.</value>
        public DateTime CreatedAt { get; set; }
    }
}
