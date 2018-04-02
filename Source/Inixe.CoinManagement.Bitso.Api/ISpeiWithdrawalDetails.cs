// -----------------------------------------------------------------------
// <copyright file="ISpeiWithdrawalDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Interface ISpeiTransferDetails
    /// </summary>
    /// <remarks>Represents the Specific data for spei transfers</remarks>
    public interface ISpeiWithdrawalDetails
    {
        /// <summary>Gets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        string BeneficiaryName { get; }

        /// <summary>Gets the beneficiary bank.</summary>
        /// <value>The beneficiary bank.</value>
        string BeneficiaryBankCode { get; }

        /// <summary>Gets the beneficiary clabe.</summary>
        /// <value>The beneficiary clabe.</value>
        string BeneficiaryClabe { get; }

        /// <summary>Gets the numeric reference.</summary>
        /// <value>The numeric reference.</value>
        string NumericReference { get; }

        /// <summary>Gets the concept.</summary>
        /// <value>The concept.</value>
        [JsonProperty("concepto")]
        string Concept { get; }

        /// <summary>Gets the tracking code.</summary>
        /// <value>The tracking code.</value>
        [JsonProperty("clave_rastreo")]
        string TrackingCode { get; }

        /// <summary>Gets the cep data.</summary>
        /// <value>The cep data.</value>
        SpeiPaymentBoucher Cep { get; }
    }
}
