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
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class BalanceUpdate
    {
        /// <summary>Gets or sets the currency identifier.</summary>
        /// <value>The currency identifier.</value>
        /// <remarks>None</remarks>
        public string Currency { get; set; }

        /// <summary>Gets or sets the updated amount.</summary>
        /// <value>The updated amount.</value>
        /// <remarks>None</remarks>
        public decimal Amount { get; set; }
    }
}
