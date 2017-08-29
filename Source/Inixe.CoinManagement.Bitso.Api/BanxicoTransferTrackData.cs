// -----------------------------------------------------------------------
// <copyright file="BanxicoTransferTrackData.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class BanxicoTransferTrackData
    /// </summary>
    public sealed class BanxicoTransferTrackData
    {
        /// <summary>Gets the query status.</summary>
        /// <value>The query status.</value>
        [JsonProperty("estadoConsulta")]
        public int QueryStatus { get; internal set; }

        /// <summary>Gets the URL.</summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>Gets the cda.</summary>
        /// <value>The cda.</value>
        [JsonProperty("cda")]
        public BanxicoData Cda { get; internal set; }
    }
}
