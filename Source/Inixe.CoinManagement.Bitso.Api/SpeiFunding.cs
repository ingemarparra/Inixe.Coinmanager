// -----------------------------------------------------------------------
// <copyright file="SpeiFunding.cs" company="Inixe">
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

    /// <summary>
    /// Class SpeiFunding
    /// </summary>
    /// <remarks>None</remarks>
    public sealed class SpeiFunding : ITransfer
    {
        private readonly FundingBase wrapped;

        /// <summary>Initializes a new instance of the <see cref="SpeiFunding"/> class.</summary>
        /// <param name="data">The data.</param>
        internal SpeiFunding(FundingBase data)
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
        public ISpeiFundingDetails Details
        {
            get
            {
                return this.wrapped.Details;
            }
        }
    }
}
