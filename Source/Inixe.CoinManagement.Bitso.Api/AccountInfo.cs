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
        /// <summary>The none value</summary>
        /// <remarks>This value should never be used. It's declared for initialization purposes only.</remarks>
        None,

        /// <summary>The active</summary>
        Active,

        /// <summary>The inactive</summary>
        Inactive,
    }

    /// <summary>
    /// Class AccountStatus
    /// </summary>
    /// <remarks>None</remarks>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public sealed class AccountInfo
    {
        /// <summary>Gets the client identifier.</summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; internal set; }

        /// <summary>Gets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; internal set; }

        /// <summary>Gets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; internal set; }

        /// <summary>Gets the status.</summary>
        /// <value>The status.</value>
        public AccountStatus Status { get; internal set; }

        /// <summary>Gets the daily limit.</summary>
        /// <value>The daily limit.</value>
        public decimal DailyLimit { get; internal set; }

        /// <summary>Gets the daily remaining.</summary>
        /// <value>The daily remaining.</value>
        public decimal DailyRemaining { get; internal set; }

        /// <summary>Gets the monthly limit.</summary>
        /// <value>The monthly limit.</value>
        public decimal MonthlyLimit { get; internal set; }

        /// <summary>Gets the cellphone number status.</summary>
        /// <value>The cellphone number status.</value>
        [JsonProperty("cellphone_number")]
        public string CellphoneNumberStatus { get; internal set; }

        /// <summary>Gets the cellphone number.</summary>
        /// <value>The cellphone number.</value>
        [JsonProperty("cellphone_number_stored")]
        public string CellphoneNumber { get; internal set; }

        /// <summary>Gets the email.</summary>
        /// <value>The email.</value>
        [JsonProperty("email_stored")]
        public string Email { get; internal set; }

        /// <summary>Gets the official identifier.</summary>
        /// <value>The official identifier.</value>
        [JsonProperty("official_id")]
        public string OfficialId { get; internal set; }

        /// <summary>Gets the proof of residency.</summary>
        /// <value>The proof of residency.</value>
        [JsonProperty("proof_of_residency")]
        public string ProofOfResidency { get; internal set; }

        /// <summary>Gets the signed contract.</summary>
        /// <value>The signed contract.</value>
        [JsonProperty("signed_contract")]
        public string SignedContract { get; internal set; }

        /// <summary>Gets the origin of funds.</summary>
        /// <value>The origin of funds.</value>
        [JsonProperty("origin_of_funds")]
        public string OriginOfFunds { get; internal set; }
    }
}
