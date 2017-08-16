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
    public class CurrencyPair
    {
        /// <summary>Gets or sets the book Name.</summary>
        /// <value>The book Name.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the minimum amount.</summary>
        /// <value>Minimum amount of major when placing orders.</value>
        public decimal MinimumAmount { get; set; }

        /// <summary>Gets or sets the maximum amount.</summary>
        /// <value>Maximum amount of major when placing orders.</value>
        public decimal MaximumAmount { get; set; }

        /// <summary>Gets or sets the minimum price.</summary>
        /// <value>Minimum price when placing orders.</value>
        public decimal MinimumPrice { get; set; }

        /// <summary>Gets or sets the maximum price.</summary>
        /// <value>Maximum price when placing orders.</value>
        public decimal MaximumPrice { get; set; }

        /// <summary>Gets or sets the minimum value.</summary>
        /// <value>Minimum value amount (amount*price) when placing orders.</value>
        public decimal MinimumValue { get; set; }

        /// <summary>Gets or sets the maximum value.</summary>
        /// <value>Maximum value amount (amount*price) when placing orders.</value>
        public decimal MaximumValue { get; set; }
    }
}
