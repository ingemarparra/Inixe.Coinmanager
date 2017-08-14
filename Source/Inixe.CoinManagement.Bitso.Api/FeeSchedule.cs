// -----------------------------------------------------------------------
// <copyright file="FeeSchedule.cs" company="Inixe">
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
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class FeeSchedule
    {
        /// <summary>Initializes a new instance of the <see cref="FeeSchedule"/> class.</summary>
        public FeeSchedule()
        {
            this.TradeFees = new List<Fee>();
            this.WithdrawalFees = new List<Fee>();
        }

        /// <summary>Gets or sets the trade fees.</summary>
        /// <value>The trade fees.</value>
        [JsonProperty("fees")]
        public IList<Fee> TradeFees { get; set; }

        /// <summary>Gets or sets the withdrawal fees.</summary>
        /// <value>The withdrawal fees.</value>
        public IList<Fee> WithdrawalFees { get; set; }
    }
}
