// -----------------------------------------------------------------------
// <copyright file="IWithdrawalBase.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Interface IWithdrawalBase
    /// </summary>
    /// <remarks>Represents the common withdrawal data, for both fiat and crypto</remarks>
    public interface IWithdrawalBase
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonProperty("wid")]
        string Id { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        TransferStatus Status { get; set; }

        /// <summary>Gets or sets the time when the withdrawal was issued.</summary>
        /// <value>The created at.</value>
        DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the currency.</summary>
        /// <value>The currency.</value>
        string Currency { get; set; }

        /// <summary>Gets or sets the method.</summary>
        /// <value>The method.</value>
        TransferMethod Method { get; set; }

        /// <summary>Gets or sets the amount.</summary>
        /// <value>The amount.</value>
        decimal Amount { get; set; }
    }
}
