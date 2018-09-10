// -----------------------------------------------------------------------
// <copyright file="SpeiWithdrawalInstruction.cs" company="Inixe">
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
    /// Class SpeiWithdrawalInstruction.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SpeiWithdrawalInstruction
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the recipient given names.
        /// </summary>
        /// <value>
        /// The recipient given names.
        /// </value>
        [JsonProperty("recipient_given_names")]
        public string BeneficiaryFirstName { get; set; }

        /// <summary>
        /// Gets or sets the recipient family names.
        /// </summary>
        /// <value>
        /// The recipient family names.
        /// </value>
        [JsonProperty("recipient_family_names")]
        public string BeneficiaryLastName { get; set; }

        /// <summary>
        /// Gets or sets the clabe.
        /// </summary>
        /// <value>
        /// The clabe.
        /// </value>
        public string Clabe { get; set; }

        /// <summary>
        /// Gets or sets the notes reference.
        /// </summary>
        /// <value>
        /// The notes reference.
        /// </value>
        [JsonProperty("notes_ref")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the numeric reference.
        /// </summary>
        /// <value>
        /// The numeric reference.
        /// </value>
        [JsonProperty("numeric_ref")]
        public int NumericReference { get; set; }
    }
}
