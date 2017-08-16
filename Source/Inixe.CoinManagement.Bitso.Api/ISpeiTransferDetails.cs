// -----------------------------------------------------------------------
// <copyright file="ISpeiTransferDetails.cs" company="Inixe">
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
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public interface ISpeiTransferDetails
    {
        /// <summary>Gets or sets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        string BeneficiaryName { get; set; }

        /// <summary>Gets or sets the beneficiary bank.</summary>
        /// <value>The beneficiary bank.</value>
        string BeneficiaryBank { get; set; }

        /// <summary>Gets or sets the beneficiary clabe.</summary>
        /// <value>The beneficiary clabe.</value>
        string BeneficiaryClabe { get; set; }

        /// <summary>Gets or sets the numeric reference.</summary>
        /// <value>The numeric reference.</value>
        string NumericReference { get; set; }

        /// <summary>Gets or sets the concept.</summary>
        /// <value>The concept.</value>
        [JsonProperty("concept")]
        string Concept { get; set; }

        /// <summary>Gets or sets the tracking code.</summary>
        /// <value>The tracking code.</value>
        [JsonProperty("clave_rastreo")]
        string TrackingCode { get; set; }

        /// <summary>Gets or sets the cep data.</summary>
        /// <value>The cep data.</value>
        SpeiReturnData Cep { get; set; }
    }
}
