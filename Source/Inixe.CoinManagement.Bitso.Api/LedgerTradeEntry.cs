﻿// -----------------------------------------------------------------------
// <copyright file="LedgerTradeEntry.cs" company="Inixe">
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
    /// Class LedgerTradeEntry
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ILedgerEntryBase" />
    /// <remarks>Represents a Trade Entry on the ledger</remarks>
    public class LedgerTradeEntry : ILedgerEntryBase
    {
        private readonly LedgerEntryBase wrapped;

        /// <summary>Initializes a new instance of the <see cref="LedgerTradeEntry"/> class.</summary>
        /// <param name="entry">The entry.</param>
        internal LedgerTradeEntry(LedgerEntryBase entry)
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

            set
            {
                throw new NotImplementedException("This is a readonly property");
            }
        }

        /// <inheritdoc/>
        public DateTime CreatedAt
        {
            get
            {
                return this.wrapped.CreatedAt;
            }

            set
            {
                throw new NotImplementedException("This is a readonly property");
            }
        }

        /// <inheritdoc/>
        public string Id
        {
            get
            {
                return this.wrapped.Id;
            }

            set
            {
                throw new NotImplementedException("This is a readonly property");
            }
        }

        /// <inheritdoc/>
        public TransactionType Kind
        {
            get
            {
                return this.wrapped.Kind;
            }

            set
            {
                throw new NotImplementedException("This is a readonly property");
            }
        }

        /// <summary>Gets the details.</summary>
        /// <value>The details.</value>
        public ITradeOperationDetails Details
        {
            get
            {
                return this.wrapped.Details;
            }
        }
    }
}