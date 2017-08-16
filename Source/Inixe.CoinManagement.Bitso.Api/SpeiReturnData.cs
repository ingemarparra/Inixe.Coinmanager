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
    /// Class SpeiReturnData
    /// </summary>
    public class SpeiReturnData
    {
        /// <summary>Gets or sets the query status.</summary>
        /// <value>The query status.</value>
        [JsonProperty("estadoConsulta")]
        public int QueryStatus { get; set; }

        /// <summary>Gets or sets the URL.</summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>Gets or sets the cda.</summary>
        /// <value>The cda.</value>
        public BanxicoData Cda { get; set; }
    }
}
