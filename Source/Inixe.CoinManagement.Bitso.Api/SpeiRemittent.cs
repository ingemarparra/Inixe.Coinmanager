// -----------------------------------------------------------------------
// <copyright file="SpeiRemittent.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class SpeiRemittent
    /// </summary>
    /// <remarks>Holds a transfer remittent data</remarks>
    public class SpeiRemittent
    {
        /// <summary>Gets or sets the transfer track data.</summary>
        /// <value>The transfer track data.</value>
        [JsonProperty("return")]
        public BanxicoTransferTrackData TransferTrackData { get; set; }
    }
}
