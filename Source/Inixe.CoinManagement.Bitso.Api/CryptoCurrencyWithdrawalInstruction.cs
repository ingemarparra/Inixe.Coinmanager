// -----------------------------------------------------------------------
// <copyright file="CryptoCurrencyWithdrawalInstruction.cs" company="Inixe">
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

    /// <summary>Class CryptoCurrencyWithdrawalInstruction</summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CryptoCurrencyWithdrawalInstruction
    {
        /// <summary>Gets or sets the currency.</summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>Gets or sets the destination tag.</summary>
        /// <value>The destination tag.</value>
        public string DestinationTag { get; set; }
    }
}
