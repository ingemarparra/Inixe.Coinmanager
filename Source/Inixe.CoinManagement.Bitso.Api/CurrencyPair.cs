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
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CurrencyPair
    {
        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the minimum amount.</summary>
        /// <value>The minimum amount.</value>
        public decimal MinimumAmount { get; set; }

        /// <summary>Gets or sets the maximum amount.</summary>
        /// <value>The maximum amount.</value>
        public decimal MaximumAmount { get; set; }

        /// <summary>Gets or sets the minimum price.</summary>
        /// <value>The minimum price.</value>
        public decimal MinimumPrice { get; set; }

        /// <summary>Gets or sets the maximum price.</summary>
        /// <value>The maximum price.</value>
        public decimal MaximumPrice { get; set; }

        /// <summary>Gets or sets the minimum value.</summary>
        /// <value>The minimum value.</value>
        public decimal MinimumValue { get; set; }

        /// <summary>Gets or sets the maximum value.</summary>
        /// <value>The maximum value.</value>
        public decimal MaximumValue { get; set; }
    }
}
