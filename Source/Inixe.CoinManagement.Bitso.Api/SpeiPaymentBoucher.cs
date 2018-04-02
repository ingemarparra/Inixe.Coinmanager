// -----------------------------------------------------------------------
// <copyright file="SpeiPaymentBoucher.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class SPEI CEP
    /// </summary>
    /// <remarks>Holds CEP data</remarks>
    public sealed class SpeiPaymentBoucher
    {
        /// <summary>Gets a value indicating whether this <see cref="SpeiPaymentBoucher"/> is success.</summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; internal set; }

        /// <summary>Gets the return data.</summary>
        /// <value>The return data.</value>
        [JsonProperty("0")]
        public SpeiRemittent Remittent { get; internal set; }
    }
}
