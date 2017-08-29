// -----------------------------------------------------------------------
// <copyright file="LedgerFundingEntry.cs" company="Inixe">
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
    /// Class LedgerFundingEntry
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ILedgerEntryBase" />
    /// <remarks>Represents a Funding Entry on the ledger</remarks>
    public sealed class LedgerFundingEntry : ILedgerEntryBase
    {
        private readonly LedgerEntryBase wrapped;

        /// <summary>Initializes a new instance of the <see cref="LedgerFundingEntry"/> class.</summary>
        /// <param name="entry">The entry.</param>
        internal LedgerFundingEntry(LedgerEntryBase entry)
        {
            this.wrapped = entry;
        }

        /// <inheritdoc/>
        public IList<BalanceUpdate> Balances
        {
            get
            {
                return this.wrapped.Balances;
            }
        }

        /// <inheritdoc/>
        public DateTime CreatedAt
        {
            get
            {
                return this.wrapped.CreatedAt;
            }
        }

        /// <inheritdoc/>
        public string Id
        {
            get
            {
                return this.wrapped.Id;
            }
        }

        /// <inheritdoc/>
        public TransactionType Kind
        {
            get
            {
                return this.wrapped.Kind;
            }
        }

        /// <summary>Gets the details.</summary>
        /// <value>The details.</value>
        public IFundingOperationDetails Details
        {
            get
            {
                return this.wrapped.Details;
            }
        }
    }
}
