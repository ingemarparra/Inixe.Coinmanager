// -----------------------------------------------------------------------
// <copyright file="ITransfer.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Interface ITransfer
    /// </summary>
    /// <remarks>Represents the common withdrawal data, for both fiat and crypto</remarks>
    public interface ITransfer
    {
        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        string Id { get; }

        /// <summary>Gets the status.</summary>
        /// <value>The status.</value>
        TransferStatus Status { get; }

        /// <summary>Gets the time when the withdrawal was issued.</summary>
        /// <value>The created at.</value>
        DateTime CreatedAt { get; }

        /// <summary>Gets the currency.</summary>
        /// <value>The currency.</value>
        string Currency { get; }

        /// <summary>Gets the method.</summary>
        /// <value>The method.</value>
        TransferMethod Method { get; }

        /// <summary>Gets the name of the method.</summary>
        /// <value>The name of the method.</value>
        string MethodName { get; }

        /// <summary>Gets the amount.</summary>
        /// <value>The amount.</value>
        decimal Amount { get; }
    }
}
