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
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class Tick
    {
        /// <summary>Gets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; internal set; }

        /// <summary>Gets the price.</summary>
        /// <value>The price.</value>
        public decimal Price { get; internal set; }

        /// <summary>Gets the amount.</summary>
        /// <value>The amount.</value>
        public decimal Amount { get; internal set; }

        /// <summary>Gets the order identifier.</summary>
        /// <value>The order identifier.</value>
        [JsonProperty("oid")]
        public string OrderId { get; internal set; }
    }
}
