// -----------------------------------------------------------------------
// <copyright file="ResponseCollection{T}.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System.Collections.Generic;

    /// <summary>
    /// Bitso API Response
    /// </summary>
    /// <typeparam name="T">The response payload Type</typeparam>
    public sealed class ResponseCollection<T>
    {
        /// <summary>Gets or sets a value indicating whether this <see cref="ResponseCollection{T}"/> is success.</summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>Gets or sets the payload.</summary>
        /// <value>The payload.</value>
        public IList<T> Payload { get; set; }
    }
}
