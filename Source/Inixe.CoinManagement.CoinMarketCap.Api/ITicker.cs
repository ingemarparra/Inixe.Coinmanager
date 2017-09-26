// <copyright file="ITicker.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface ITicker
    /// </summary>
    public interface ITicker
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        string Id { get; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>Gets the symbol.</summary>
        /// <value>The symbol.</value>
        string Symbol { get; }

        /// <summary>Gets the rank.</summary>
        /// <value>The rank.</value>
        int Rank { get; }

        /// <summary>Gets the available supply.</summary>
        /// <value>The available supply.</value>
        decimal AvailableSupply { get; }

        /// <summary>Gets the total supply.</summary>
        /// <value>The total supply.</value>
        decimal TotalSupply { get; }

        /// <summary>Gets the percent change1 h.</summary>
        /// <value>The percent change1 h.</value>
        decimal PercentChange1H { get; }

        /// <summary>Gets the percent change24 h.</summary>
        /// <value>The percent change24 h.</value>
        decimal PercentChange24H { get; }

        /// <summary>Gets the percent change7 d.</summary>
        /// <value>The percent change7 d.</value>
        decimal PercentChange7D { get; }

        /// <summary>Gets the last updated.</summary>
        /// <value>The last updated.</value>
        DateTime LastUpdated { get; }

        /// <summary>Gets the price.</summary>
        /// <value>The price.</value>
        IDictionary<FiatCurrency, decimal> Price { get; }

        /// <summary>Gets the volume24 h.</summary>
        /// <value>The volume24 h.</value>
        IDictionary<FiatCurrency, decimal> Volume24H { get; }

        /// <summary>Gets the market cap.</summary>
        /// <value>The market cap.</value>
        IDictionary<FiatCurrency, decimal> MarketCap { get; }
    }
}
