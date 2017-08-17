// -----------------------------------------------------------------------
// <copyright file="CryptoCurrencyWithdrawal.cs" company="Inixe">
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
    /// Class CryptoCurrencyWithdrawal
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.IWithdrawalBase" />
    public class CryptoCurrencyWithdrawal : IWithdrawalBase
    {
        private readonly WithdrawalBase wrapped;

        /// <summary>Initializes a new instance of the <see cref="CryptoCurrencyWithdrawal"/> class.</summary>
        /// <param name="data">The data.</param>
        internal CryptoCurrencyWithdrawal(WithdrawalBase data)
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

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <inheritdoc/>
        public TransferStatus Status
        {
            get
            {
                return this.wrapped.Status;
            }

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
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
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <inheritdoc/>
        public string Currency
        {
            get
            {
                return this.wrapped.Currency;
            }

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <inheritdoc/>
        public string MethodName
        {
            get
            {
                return this.wrapped.MethodName;
            }

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <inheritdoc/>
        public TransferMethod Method
        {
            get
            {
                return this.wrapped.Method;
            }

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <inheritdoc/>
        public decimal Amount
        {
            get
            {
                return this.wrapped.Amount;
            }

            set
            {
                throw new InvalidOperationException("This is a readonly instance");
            }
        }

        /// <summary>Gets the details.</summary>
        /// <value>The details.</value>
        public ICrytoCurrencyWithdrawalDetails Details
        {
            get
            {
                return this.wrapped.Details;
            }
        }
    }
}
