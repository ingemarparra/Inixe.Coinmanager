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

    /// <summary>
    /// Class BitsoException
    /// </summary>
    /// <remarks>None</remarks>
    public sealed class BitsoException : Exception
    {
        private readonly ApiError errorInfo;
        private readonly string authHeader;

        internal BitsoException(string content, string authHeader)
        {
            JsonSerializer serializer = new JsonSerializer();

            var res = serializer.Deserialize<ErrorResponse>(content);
            this.errorInfo = res.Error;
            this.authHeader = authHeader;
        }

        internal BitsoException(string content)
            : this(content, string.Empty)
        {
        }

        public string Header { get { return this.authHeader; } }

        public override string Message
        {
            get
            {
                return this.errorInfo.Message;
            }
        }

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
