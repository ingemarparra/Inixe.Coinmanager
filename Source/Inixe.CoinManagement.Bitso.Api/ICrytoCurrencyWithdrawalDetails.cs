// -----------------------------------------------------------------------
// <copyright file="ICrytoCurrencyWithdrawalDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Interface ICrytoCurrencyTransferDetails
    /// </summary>
    /// <remarks>Represents the a Crypto currency transfer details</remarks>
    public interface ICrytoCurrencyWithdrawalDetails
    {
        /// <summary>Gets or sets the withdrawal address.</summary>
        /// <value>The withdrawal address.</value>
        string WithdrawalAddress { get; set; }

        /// <summary>Gets or sets the transfer hash.</summary>
        /// <value>The transfer hash.</value>
        [JsonProperty("tx_hash")]
        string TransferHash { get; set; }
    }
}
