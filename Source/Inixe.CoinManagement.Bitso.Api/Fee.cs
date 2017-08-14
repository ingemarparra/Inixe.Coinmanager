// -----------------------------------------------------------------------
// <copyright file="Fee.cs" company="Inixe">
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
    /// Class Fee
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Fee
    {
        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        [JsonProperty("fee_decimal")]
        public decimal Value { get; set; }

        /// <summary>Gets or sets the percent.</summary>
        /// <value>The percent.</value>
        [JsonProperty("fee_percent")]
        public decimal Percent { get; set; }
    }
}
