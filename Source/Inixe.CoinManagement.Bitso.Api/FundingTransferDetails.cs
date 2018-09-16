// -----------------------------------------------------------------------
// <copyright file="FundingTransferDetails.cs" company="Inixe">
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
    /// Class FundingTransferDetails
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class FundingTransferDetails : ICrytoCurrencyFundingDetails, ISpeiFundingDetails, IBitsoTransferFundingDetails
    {
        /// <inheritdoc/>
        public string SenderName { get; set; }

        /// <inheritdoc/>
        public string SenderBank { get; set; }

        /// <inheritdoc/>
        public string SenderClabe { get; set; }

        /// <inheritdoc/>
        public string RecievingClabe { get; set; }

        /// <inheritdoc/>
        public string NumericReference { get; set; }

        /// <inheritdoc/>
        public string Concept { get; set; }

        /// <inheritdoc/>
        public string TrackingCode { get; set; }

        /// <inheritdoc/>
        public string BeneficiaryName { get; set; }

        /// <inheritdoc/>
        public string FundingAddress { get; set; }

        /// <inheritdoc/>
        public string TransferHash { get; set; }

        /// <inheritdoc/>
        public string Notes { get; set; }
    }
}
