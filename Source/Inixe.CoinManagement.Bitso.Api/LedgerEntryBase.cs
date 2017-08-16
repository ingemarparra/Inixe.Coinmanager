// -----------------------------------------------------------------------
// <copyright file="LedgerEntryBase.cs" company="Inixe">
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
    /// Enum TransactionType
    /// </summary>
    /// <remarks>Represents the diferent Kinds of operations</remarks>
    public enum TransactionType
    {
        /// <summary>The fee charge transaction</summary>
        Fee,

        /// <summary>A Withdrawal transaction</summary>
        Withdrawal,

        /// <summary>A funding transaction</summary>
        Funding,

        /// <summary>A trade</summary>
        Trade,
    }

    /// <summary>
    /// Class Ledger
    /// </summary>
    /// <remarks>None</remarks>
    internal class LedgerEntryBase : ILedgerEntry
    {
        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public TransactionType Kind { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc/>
        public IList<BalanceUpdate> Balances { get; set; }

        /// <summary>Gets or sets the operation details details.</summary>
        /// <value>The details.</value>
        public LedgerEntryDetails Details { get; set; }

        /// <inheritdoc/>
        public T GetDetails<T>()
            where T : IFundingOperationDetails, IWithdrawalOperationDetails, ITradeOperationDetails
        {
            T retval;
            switch (this.Kind)
            {
                case TransactionType.Fee:
                    retval = (T)(ITradeOperationDetails)this.Details;
                    break;
                case TransactionType.Funding:
                    retval = (T)(IFundingOperationDetails)this.Details;
                    break;
                case TransactionType.Trade:
                    retval = (T)(ITradeOperationDetails)this.Details;
                    break;
                case TransactionType.Withdrawal:
                    retval = (T)(IWithdrawalOperationDetails)this.Details;
                    break;
                default:
                    throw new InvalidOperationException("Unknown details type");
            }

            return retval;
        }
    }
}
