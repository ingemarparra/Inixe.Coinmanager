// -----------------------------------------------------------------------
// <copyright file="Position.cs" company="Inixe">
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
    /// Class Position
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Position
    {
        /// <summary>Gets or sets the currency name.</summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>Gets or sets the total amount for the currency.</summary>
        /// <value>The total.</value>
        public decimal Total { get; set; }

        /// <summary>Gets or sets the locked amount in orders.</summary>
        /// <value>The locked.</value>
        public decimal Locked { get; set; }

        /// <summary>Gets or sets the available amount.</summary>
        /// <value>The available.</value>
        public decimal Available { get; set; }
    }
}
