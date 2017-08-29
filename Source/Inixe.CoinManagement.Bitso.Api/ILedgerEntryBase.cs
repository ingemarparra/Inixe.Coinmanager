// <copyright file="ILedgerEntryBase.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Interface ILedgerEntry
    /// </summary>
    /// <remarks>Represents base Ledger data</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public interface ILedgerEntryBase
    {
        /// <summary>Gets the balances updates made after the operations is done.</summary>
        /// <value>The balances.</value>
        /// <remarks>Once the operation is done a balance summary for every currency involved is generated. Every balance update summarises the amount been affected for the currency balance.</remarks>
        [JsonProperty("balance_updates")]
        IList<BalanceUpdate> Balances { get; }

        /// <summary>Gets the created at date.</summary>
        /// <value>The created at.</value>
        /// <remarks>None</remarks>
        DateTime CreatedAt { get; }

        /// <summary>Gets the ledger identifier.</summary>
        /// <value>The ledger identifier.</value>
        /// <remarks>None</remarks>
        [JsonProperty("eid")]
        string Id { get; }

        /// <summary>Gets the Ledger entry kind.</summary>
        /// <value>The ledger entry kind.</value>
        /// <remarks>None</remarks>
        [JsonProperty("operation", ItemConverterType = typeof(StringEnumConverter))]
        TransactionType Kind { get; }
    }
}