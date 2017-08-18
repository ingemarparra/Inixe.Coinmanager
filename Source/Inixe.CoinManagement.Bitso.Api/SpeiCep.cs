// -----------------------------------------------------------------------
// <copyright file="SpeiCep.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class SPEI CEP
    /// </summary>
    /// <remarks>Holds CEP data</remarks>
    public class SpeiCep
    {
        /// <summary>Gets or sets a value indicating whether this <see cref="SpeiCep"/> is success.</summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>Gets or sets the return data.</summary>
        /// <value>The return data.</value>
        [JsonProperty("0")]
        public SpeiRemittent Remittent { get; set; }
    }
}
