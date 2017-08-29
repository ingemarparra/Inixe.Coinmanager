// -----------------------------------------------------------------------
// <copyright file="ICrytoCurrencyFundingDetails.cs" company="Inixe">
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

    /// <summary>
    /// Interface ICrytoCurrencyFundingDetails
    /// </summary>
    /// <remarks>None</remarks>
    public interface ICrytoCurrencyFundingDetails
    {
        /// <summary>Gets the withdrawal address.</summary>
        /// <value>The withdrawal address.</value>
        [JsonProperty("funding_address")]
        string FundingAddress { get; }

        /// <summary>Gets the transfer hash.</summary>
        /// <value>The transfer hash.</value>
        [JsonProperty("tx_hash")]
        string TransferHash { get; }
    }
}
