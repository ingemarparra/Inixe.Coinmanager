// -----------------------------------------------------------------------
// <copyright file="BitsoException.cs" company="Inixe">
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
    using Inixe.CoinManagement.Bitso.Api.Serialization;

    /// <summary>
    /// Class BitsoException
    /// </summary>
    /// <remarks>None</remarks>
    public sealed class BitsoException : Exception
    {
        private readonly ApiError errorInfo;
        private readonly string authHeader;

        /// <summary>Initializes a new instance of the <see cref="BitsoException"/> class.</summary>
        /// <param name="content">The content.</param>
        /// <param name="authHeader">The authentication header.</param>
        internal BitsoException(string content, string authHeader)
        {
            var serializer = new BitsoJsonSerializer();

            var res = serializer.Deserialize<ErrorResponse>(content);
            this.errorInfo = res.Error;
            this.authHeader = authHeader;
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoException"/> class.</summary>
        /// <param name="content">The content.</param>
        internal BitsoException(string content)
            : this(content, string.Empty)
        {
        }

        /// <summary>Gets the header.</summary>
        /// <value>The header.</value>
        public string Header
        {
            get
            {
                return this.authHeader;
            }
        }

        /// <summary>Gets a message that describes the current exception.</summary>
        public override string Message
        {
            get
            {
                return this.errorInfo.Message;
            }
        }

        /// <summary>Gets the code.</summary>
        /// <value>The code.</value>
        public string Code
        {
            get
            {
                return this.errorInfo.Code;
            }
        }

        private class ErrorResponse
        {
            public bool Success { get; set; }

            public ApiError Error { get; set; }
        }

        private class ApiError
        {
            public string Message { get; set; }

            public string Code { get; set; }
        }
    }
}
