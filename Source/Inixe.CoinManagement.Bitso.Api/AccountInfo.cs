// -----------------------------------------------------------------------
// <copyright file="AccountInfo.cs" company="Inixe">
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
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Enum Status
    /// </summary>
    /// <remarks>Account Status</remarks>
    public enum AccountStatus
    {
        /// <summary>The active</summary>
        Active,

        /// <summary>The inactive</summary>
        Inactive,
    }

    /// <summary>
    /// Class AccountStatus
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AccountInfo
    {
        /// <summary>Gets or sets the client identifier.</summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public AccountStatus Status { get; set; }

        /// <summary>Gets or sets the daily limit.</summary>
        /// <value>The daily limit.</value>
        public decimal DailyLimit { get; set; }

        /// <summary>Gets or sets the daily remaining.</summary>
        /// <value>The daily remaining.</value>
        public decimal DailyRemaining { get; set; }

        /// <summary>Gets or sets the monthly limit.</summary>
        /// <value>The monthly limit.</value>
        public decimal MonthlyLimit { get; set; }

        /// <summary>Gets or sets the cellphone number status.</summary>
        /// <value>The cellphone number status.</value>
        [JsonProperty("cellphone_number")]
        public string CellphoneNumberStatus { get; set; }

        /// <summary>Gets or sets the cellphone number.</summary>
        /// <value>The cellphone number.</value>
        [JsonProperty("cellphone_number_stored")]
        public string CellphoneNumber { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [JsonProperty("email_stored")]
        public string Email { get; set; }

        /// <summary>Gets or sets the official identifier.</summary>
        /// <value>The official identifier.</value>
        [JsonProperty("official_id")]
        public string OfficialId { get; set; }

        /// <summary>Gets or sets the proof of residency.</summary>
        /// <value>The proof of residency.</value>
        [JsonProperty("proof_of_residency")]
        public string ProofOfResidency { get; set; }

        /// <summary>Gets or sets the signed contract.</summary>
        /// <value>The signed contract.</value>
        [JsonProperty("signed_contract")]
        public string SignedContract { get; set; }

        /// <summary>Gets or sets the origin of funds.</summary>
        /// <value>The origin of funds.</value>
        [JsonProperty("origin_of_funds")]
        public string OriginOfFunds { get; set; }
    }
}
