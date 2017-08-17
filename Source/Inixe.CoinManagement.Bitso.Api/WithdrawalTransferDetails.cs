// -----------------------------------------------------------------------
// <copyright file="WithdrawalTransferDetails.cs" company="Inixe">
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
    /// Class TransferDetails
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ICrytoCurrencyWithdrawalDetails" />
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ISpeiWithdrawalDetails" />
    /// <remarks>For internal use only.</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class WithdrawalTransferDetails : ICrytoCurrencyWithdrawalDetails, ISpeiWithdrawalDetails
    {
        /// <inheritdoc/>
        public string WithdrawalAddress { get; set; }

        /// <inheritdoc/>
        public string TransferHash { get; set; }

        /// <inheritdoc/>
        public string BeneficiaryName { get; set; }

        /// <inheritdoc/>
        public string BeneficiaryBankCode { get; set; }

        /// <inheritdoc/>
        public string BeneficiaryClabe { get; set; }

        /// <inheritdoc/>
        public string NumericReference { get; set; }

        /// <inheritdoc/>
        public string Concept { get; set; }

        /// <inheritdoc/>
        public string TrackingCode { get; set; }

        /// <inheritdoc/>
        public SpeiCep Cep { get; set; }
    }
}
