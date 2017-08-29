// -----------------------------------------------------------------------
// <copyright file="SpeiWithdrawal.cs" company="Inixe">
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
    /// Class SpeiWithdrawal
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ITransfer" />
    public sealed class SpeiWithdrawal : ITransfer
    {
        private readonly WithdrawalBase wrapped;

        /// <summary>Initializes a new instance of the <see cref="SpeiWithdrawal"/> class.</summary>
        /// <param name="data">The data.</param>
        internal SpeiWithdrawal(WithdrawalBase data)
        {
            this.wrapped = data;
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
        public TransferStatus Status
        {
            get
            {
                return this.wrapped.Status;
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
        public string Currency
        {
            get
            {
                return this.wrapped.Currency;
            }
        }

        /// <inheritdoc/>
        public string MethodName
        {
            get
            {
                return this.wrapped.MethodName;
            }
        }

        /// <inheritdoc/>
        public TransferMethod Method
        {
            get
            {
                return this.wrapped.Method;
            }
        }

        /// <inheritdoc/>
        public decimal Amount
        {
            get
            {
                return this.wrapped.Amount;
            }
        }

        /// <summary>Gets the details.</summary>
        /// <value>The details.</value>
        public ISpeiWithdrawalDetails Details
        {
            get
            {
                return this.wrapped.Details;
            }
        }
    }
}
