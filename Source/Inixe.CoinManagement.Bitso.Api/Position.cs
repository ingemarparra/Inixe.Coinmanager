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
    public sealed class Position
    {
        /// <summary>Gets the currency name.</summary>
        /// <value>The currency.</value>
        public string Currency { get; internal set; }

        /// <summary>Gets the total amount for the currency.</summary>
        /// <value>The total.</value>
        public decimal Total { get; internal set; }

        /// <summary>Gets the locked amount in orders.</summary>
        /// <value>The locked.</value>
        public decimal Locked { get; internal set; }

        /// <summary>Gets the available amount.</summary>
        /// <value>The available.</value>
        public decimal Available { get; internal set; }
    }
}
