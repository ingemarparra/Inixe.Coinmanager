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
        /// <summary>Gets the withdrawal address.</summary>
        /// <value>The withdrawal address.</value>
        [JsonProperty("withdrawal_address")]
        string WithdrawalAddress { get; }

        /// <summary>Gets the transfer hash.</summary>
        /// <value>The transfer hash.</value>
        [JsonProperty("tx_hash")]
        string TransferHash { get; }
    }
}
