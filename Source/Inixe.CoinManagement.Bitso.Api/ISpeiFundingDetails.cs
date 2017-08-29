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
        /// <summary>Gets the name of the sender.</summary>
        /// <value>The name of the sender.</value>
        string SenderName { get; }

        /// <summary>Gets the sender bank.</summary>
        /// <value>The sender bank.</value>
        string SenderBank { get; }

        /// <summary>Gets the sender clabe.</summary>
        /// <value>The sender clabe.</value>
        string SenderClabe { get; }

        /// <summary>Gets the recieving clabe.</summary>
        /// <value>The recieving clabe.</value>
        [JsonProperty("receive_clabe")]
        string RecievingClabe { get; }

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

        /// <summary>Gets the name of the beneficiary.</summary>
        /// <value>The name of the beneficiary.</value>
        string BeneficiaryName { get; }
    }
}
