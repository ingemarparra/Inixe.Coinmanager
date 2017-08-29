// -----------------------------------------------------------------------
// <copyright file="BalanceUpdate.cs" company="Inixe">
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
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class BalanceUpdate
    /// </summary>
    /// <remarks>Represents a Balace Change</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class BalanceUpdate
    {
        /// <summary>Gets the currency identifier.</summary>
        /// <value>The currency identifier.</value>
        /// <remarks>None</remarks>
        public string Currency { get; internal set; }

        /// <summary>Gets the updated amount.</summary>
        /// <value>The updated amount.</value>
        /// <remarks>None</remarks>
        public decimal Amount { get; internal set; }
    }
}
