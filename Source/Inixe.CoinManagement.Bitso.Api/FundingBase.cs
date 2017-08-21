// -----------------------------------------------------------------------
// <copyright file="FundingBase.cs" company="Inixe">
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
    /// Class Funding
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class FundingBase : ITransfer
    {
        /// <inheritdoc/>
        [JsonProperty("fid")]
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
        public FundingTransferDetails Details { get; set; }
    }
}
