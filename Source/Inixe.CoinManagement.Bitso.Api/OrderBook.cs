// -----------------------------------------------------------------------
// <copyright file="OrderBook.cs" company="Inixe">
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
    /// Class OrderBook
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OrderBook
    {
        /// <summary>Initializes a new instance of the <see cref="OrderBook"/> class.</summary>
        public OrderBook()
        {
            this.Asks = new List<Tick>();
            this.Bids = new List<Tick>();
        }

        /// <summary>Gets or sets the asks.</summary>
        /// <value>The asks.</value>
        public IList<Tick> Asks { get; set; }

        /// <summary>Gets or sets the bids.</summary>
        /// <value>The bids.</value>
        public IList<Tick> Bids { get; set; }

        /// <summary>Gets or sets the updated at.</summary>
        /// <value>The updated at.</value>
        public DateTime UpdatedAt { get; set; }

        /// <summary>Gets or sets the sequence.</summary>
        /// <value>The sequence.</value>
        public long Sequence { get; set; }
    }
}
