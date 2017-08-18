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
