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
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Ticker
    {
        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public string Book { get; set; }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>The volume.</value>
        public decimal Volume { get; set; }

        /// <summary>Gets or sets the high.</summary>
        /// <value>The high.</value>
        public decimal High { get; set; }

        /// <summary>Gets or sets the last.</summary>
        /// <value>The last.</value>
        public decimal Last { get; set; }

        /// <summary>Gets or sets the low.</summary>
        /// <value>The low.</value>
        public decimal Low { get; set; }

        /// <summary>Gets or sets the vwap.</summary>
        /// <value>The vwap.</value>
        public decimal Vwap { get; set; }

        /// <summary>Gets or sets the ask.</summary>
        /// <value>The ask.</value>
        public decimal Ask { get; set; }

        /// <summary>Gets or sets the bid.</summary>
        /// <value>The bid.</value>
        public decimal Bid { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; }
    }
}
