// -----------------------------------------------------------------------
// <copyright file="Portfolio.cs" company="Inixe">
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
    /// Class Portfolio
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class Portfolio
    {
        /// <summary>Initializes a new instance of the <see cref="Portfolio"/> class.</summary>
        public Portfolio()
        {
            this.Balances = new List<Position>();
        }

        /// <summary>Gets the balances.</summary>
        /// <value>The balances.</value>
        public IList<Position> Balances { get; internal set; }
    }
}
