// -----------------------------------------------------------------------
// <copyright file="ISpeiFundingDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Interface ISpeiFundingDetails
    /// </summary>
    /// <remarks>None</remarks>
    public interface ISpeiFundingDetails
    {
        /// <summary>Gets or sets the name of the sender.</summary>
        /// <value>The name of the sender.</value>
        string SenderName { get; set; }

        /// <summary>Gets or sets the sender bank.</summary>
        /// <value>The sender bank.</value>
        string SenderBank { get; set; }

        /// <summary>Gets or sets the sender clabe.</summary>
        /// <value>The sender clabe.</value>
        string SenderClabe { get; set; }

        /// <summary>Gets or sets the recieving clabe.</summary>
        /// <value>The recieving clabe.</value>
        [JsonProperty("receive_clabe")]
        string RecievingClabe { get; set; }

        /// <summary>Gets or sets the numeric reference.</summary>
        /// <value>The numeric reference.</value>
        string NumericReference { get; set; }

        /// <summary>Gets or sets the concept.</summary>
        /// <value>The concept.</value>
        [JsonProperty("concepto")]
        string Concept { get; set; }

        /// <summary>Gets or sets the tracking code.</summary>
        /// <value>The tracking code.</value>
        [JsonProperty("clave_rastreo")]
        string TrackingCode { get; set; }

        /// <summary>Gets or sets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        string BeneficiaryName { get; set; }
    }
}
