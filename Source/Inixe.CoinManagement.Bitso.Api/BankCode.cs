// -----------------------------------------------------------------------
// <copyright file="BankCode.cs" company="Inixe">
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
    /// Class BankCode
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class BankCode
    {
        /// <summary>Gets the code.</summary>
        /// <value>The code.</value>
        public string Code { get; internal set; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }
    }
}
