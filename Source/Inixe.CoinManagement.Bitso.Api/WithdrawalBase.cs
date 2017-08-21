// -----------------------------------------------------------------------
// <copyright file="WithdrawalBase.cs" company="Inixe">
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
    /// Enum TransferStatus
    /// </summary>
    public enum TransferStatus
    {
        /// <summary>The none value</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>Pending Transfer</summary>
        Pending,

        /// <summary>Completed Transfer</summary>
        Complete,

        /// <summary>Cancelled transfer</summary>
        Cancelled,

        /// <summary>The transfer is being Processed</summary>
        Processing,
    }

    /// <summary>
    /// Enum TransferMethod
    /// </summary>
    public enum TransferMethod
    {
        /// <summary>The none value</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>The Spei Method</summary>
        Sp,

        /// <summary>The bitcoin method</summary>
        Btc,

        /// <summary>The ether method</summary>
        Eth,

        /// <summary>The ripple method</summary>
        Rp,
    }

    /// <summary>
    /// Class Withdrawal
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class WithdrawalBase : ITransfer
    {
        /// <inheritdoc/>
        [JsonProperty("wid")]
        public string Id { get; set; }

        /// <inheritdoc/>
        public TransferStatus Status { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public string Currency { get; set; }

        /// <inheritdoc/>
        public TransferMethod Method { get; set; }

        /// <inheritdoc/>
        public string MethodName { get; set; }

        /// <inheritdoc/>
        public decimal Amount { get; set; }

        /// <summary>Gets or sets the details.</summary>
        /// <value>The details.</value>
        public WithdrawalTransferDetails Details { get; set; }
    }
}
