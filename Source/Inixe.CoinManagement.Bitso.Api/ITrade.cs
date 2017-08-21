// <copyright file="ITrade.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface Trade
    /// </summary>
    /// <remarks>Represents the Basic trade data</remarks>
    public interface ITrade
    {
        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        string BookName { get; set; }

        /// <summary>Gets or sets the created at.</summary>
        /// <value>The created at.</value>
        DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the maker side.</summary>
        /// <value>The maker side.</value>
        MarketSide MakerSide { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        decimal Price { get; set; }

        /// <summary>Gets or sets the trade identifier.</summary>
        /// <value>The trade identifier.</value>
        [JsonProperty("tid")]
        long TradeId { get; set; }
    }
}