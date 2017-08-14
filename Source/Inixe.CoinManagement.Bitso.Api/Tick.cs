// -----------------------------------------------------------------------
// <copyright file="Tick.cs" company="Inixe">
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
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class Tick
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Tick
    {
        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the order identifier.</summary>
        /// <value>The order identifier.</value>
        [JsonProperty("oid")]
        public string OrderId { get; set; }
    }
}
