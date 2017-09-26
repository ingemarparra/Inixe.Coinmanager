// <copyright file="Ticker.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class Ticker
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.CoinMarketCap.Api.ITicker" />
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal sealed class Ticker : ITicker
    {
        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string Symbol { get; set; }

        /// <inheritdoc/>
        public int Rank { get; set; }

        /// <inheritdoc/>
        public decimal AvailableSupply { get; set; }

        /// <inheritdoc/>
        public decimal TotalSupply { get; set; }

        /// <inheritdoc/>
        public decimal PercentChange1H { get; set; }

        /// <inheritdoc/>
        public decimal PercentChange24H { get; set; }

        /// <inheritdoc/>
        public decimal PercentChange7D { get; set; }

        /// <inheritdoc/>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastUpdated { get; set; }

        /// <inheritdoc/>
        [JsonConverter(typeof(FiatKeyValueJsonConverter))]
        public IDictionary<FiatCurrency, decimal> Price { get; set; }

        /// <inheritdoc/>
        [JsonConverter(typeof(FiatKeyValueJsonConverter))]
        public IDictionary<FiatCurrency, decimal> Volume24H { get; set; }

        /// <inheritdoc/>
        [JsonConverter(typeof(FiatKeyValueJsonConverter))]
        public IDictionary<FiatCurrency, decimal> MarketCap { get; set; }
    }
}
