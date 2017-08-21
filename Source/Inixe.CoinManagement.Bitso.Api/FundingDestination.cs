// -----------------------------------------------------------------------
// <copyright file="FundingDestination.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Class FundingDestination
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class FundingDestination
    {
        /// <summary>Gets or sets the name of the account identifier.</summary>
        /// <value>The name of the account identifier.</value>
        public string AccountIdentifierName { get; set; }

        /// <summary>Gets or sets the account identifier.</summary>
        /// <value>The account identifier.</value>
        public string AccountIdentifier { get; set; }
    }
}
