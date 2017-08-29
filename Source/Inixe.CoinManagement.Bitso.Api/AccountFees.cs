// -----------------------------------------------------------------------
// <copyright file="AccountFees.cs" company="Inixe">
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
    /// Class FeeSchedule
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class AccountFees
    {
        /// <summary>Initializes a new instance of the <see cref="AccountFees"/> class.</summary>
        public AccountFees()
        {
            this.TradeFees = new List<Fee>();
            this.WithdrawalFees = new Dictionary<string, decimal>();
        }

        /// <summary>Gets the trade fees.</summary>
        /// <value>The trade fees.</value>
        [JsonProperty("fees")]
        public IList<Fee> TradeFees { get; internal set; }

        /// <summary>Gets the withdrawal fees.</summary>
        /// <value>The withdrawal fees.</value>
        public Dictionary<string, decimal> WithdrawalFees { get; internal set; }
    }
}
