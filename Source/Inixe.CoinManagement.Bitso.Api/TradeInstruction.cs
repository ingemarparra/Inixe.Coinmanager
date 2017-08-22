// -----------------------------------------------------------------------
// <copyright file="TradeInstruction.cs" company="Inixe">
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
    /// Class TradeInstruction
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TradeInstruction
    {
        private CurrencyPair pair;

        /// <summary>Initializes a new instance of the <see cref="TradeInstruction"/> class.</summary>
        public TradeInstruction()
            : this(string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TradeInstruction"/> class.</summary>
        /// <param name="pair">The pair.</param>
        public TradeInstruction(CurrencyPair pair)
        {
            this.Pair = pair;
        }

        /// <summary>Initializes a new instance of the <see cref="TradeInstruction"/> class.</summary>
        /// <param name="bookName">Name of the book.</param>
        public TradeInstruction(string bookName)
        {
            this.BookName = bookName;
        }

        /// <summary>Gets or sets the pair.</summary>
        /// <value>The pair.</value>
        [JsonIgnore]
        public CurrencyPair Pair
        {
            get
            {
                return this.pair;
            }

            set
            {
                this.pair = value;
                this.BookName = this.pair != null ? this.pair.BookName : string.Empty;
            }
        }

        /// <summary>Gets or sets the name of the book.</summary>
        /// <value>The name of the book.</value>
        [JsonProperty("book")]
        public string BookName { get; set; }

        /// <summary>Gets or sets the side.</summary>
        /// <value>The side.</value>
        public MarketSide Side { get; set; }

        /// <summary>Gets or sets the type of the order.</summary>
        /// <value>The type of the order.</value>
        [JsonProperty("type")]
        public TradeOrderType OrderType { get; set; }

        /// <summary>Gets or sets the major currency amount.</summary>
        /// <value>The major currency amount.</value>
        [JsonProperty("major")]
        public decimal? MajorCurrencyAmount { get; set; }

        /// <summary>Gets or sets the minor currency amount.</summary>
        /// <value>The minor currency amount.</value>
        [JsonProperty("minor")]
        public decimal? MinorCurrencyAmount { get; set; }

        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public decimal Price { get; set; }
    }
}
