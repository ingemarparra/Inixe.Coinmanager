// -----------------------------------------------------------------------
// <copyright file="CurrencyPair.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// An order book
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class CurrencyPair
    {
        /// <summary>Gets the book Name.</summary>
        /// <value>The book Name.</value>
        [JsonProperty("book")]
        public string BookName { get; internal set; }

        /// <summary>Gets the minimum amount.</summary>
        /// <value>Minimum amount of major when placing orders.</value>
        public decimal MinimumAmount { get; internal set; }

        /// <summary>Gets the maximum amount.</summary>
        /// <value>Maximum amount of major when placing orders.</value>
        public decimal MaximumAmount { get; internal set; }

        /// <summary>Gets the minimum price.</summary>
        /// <value>Minimum price when placing orders.</value>
        public decimal MinimumPrice { get; internal set; }

        /// <summary>Gets the maximum price.</summary>
        /// <value>Maximum price when placing orders.</value>
        public decimal MaximumPrice { get; internal set; }

        /// <summary>Gets the minimum value.</summary>
        /// <value>Minimum value amount (amount*price) when placing orders.</value>
        public decimal MinimumValue { get; internal set; }

        /// <summary>Gets the maximum value.</summary>
        /// <value>Maximum value amount (amount*price) when placing orders.</value>
        public decimal MaximumValue { get; internal set; }
    }
}
