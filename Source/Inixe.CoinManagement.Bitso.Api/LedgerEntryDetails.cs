// -----------------------------------------------------------------------
// <copyright file="LedgerEntryDetails.cs" company="Inixe">
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
    using Inixe.CoinManagement.Bitso.Api.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class LedgerEntryDetails
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.IFundingOperationDetails" />
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.IWithdrawalOperationDetails" />
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ITradeOperationDetails" />
    /// <remarks>This acts like a facade for the different operations detiails.</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal sealed class LedgerEntryDetails : IFundingOperationDetails, IWithdrawalOperationDetails, ITradeOperationDetails
    {
        /// <inheritdoc/>
        [JsonProperty("fid")]
        public string FundsOperationId { get; set; }

        /// <inheritdoc/>
        public string Method { get; set; }

        /// <inheritdoc/>
        [JsonProperty("funding_address")]
        public string Address { get; set; }

        /// <inheritdoc/>
        [JsonProperty("wid")]
        public string WithdrawalOperationId { get; set; }

        /// <inheritdoc/>
        [JsonProperty("withdrawal_address")]
        public string BenficiaryAddress { get; set; }

        /// <inheritdoc/>
        [JsonProperty("tid")]
        public long TradeId { get; set; }

        /// <inheritdoc/>
        [JsonProperty("oid")]
        public string OrderId { get; set; }
    }
}
