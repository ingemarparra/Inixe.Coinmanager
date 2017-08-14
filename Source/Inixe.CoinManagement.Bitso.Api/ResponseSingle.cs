// -----------------------------------------------------------------------
// <copyright file="ResponseSingle.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    /// <summary>
    /// Class ResponseSingle{T}
    /// </summary>
    /// <typeparam name="T">The payload type</typeparam>
    public sealed class ResponseSingle<T>
    {
        /// <summary>Gets or sets a value indicating whether this <see cref="ResponseCollection{T}"/> is success.</summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>Gets or sets the payload.</summary>
        /// <value>The payload.</value>
        public T Payload { get; set; }
    }
}
