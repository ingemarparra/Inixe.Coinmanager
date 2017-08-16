// -----------------------------------------------------------------------
// <copyright file="HttpClientBase.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    using RestSharp;

    /// <summary>
    /// Class HttpClientBase
    /// </summary>
    /// <remarks>None</remarks>
    public class HttpClientBase : IDisposable
    {
        private readonly RestClient client;
        private readonly string apiKey;
        private readonly SecureString secureApiSecret;
        private readonly Uri targetUrl;

        private bool disposedValue;

        /// <summary>Initializes a new instance of the <see cref="HttpClientBase"/> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        protected HttpClientBase(string serverUrl, string apiKey, string apiSecret)
            : this(serverUrl, apiKey, CreateSecureApiSecret(apiSecret))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HttpClientBase"/> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The Api key value</param>
        /// <param name="apiSecret">The Api secret value</param>
        /// <exception cref="ArgumentException">Invalid URL - serverUrl</exception>
        /// <remarks>None</remarks>
        protected HttpClientBase(string serverUrl, string apiKey, SecureString apiSecret)
        {
            if (!System.Uri.IsWellFormedUriString(serverUrl, System.UriKind.Absolute))
            {
                throw new ArgumentException("Invalid URL", nameof(serverUrl));
            }

            this.secureApiSecret = apiSecret;

            this.apiKey = apiKey;
            this.targetUrl = new Uri(serverUrl);
            this.client = new RestClient(serverUrl);
            this.disposedValue = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether automatic error handling is enabled.
        /// </summary>
        /// <value><c>true</c> if automatic errors handling is enabled; otherwise, <c>false</c>.</value>
        /// <remarks>When Enabled. No Client exceptions are thrown on API calls, all api call results will be null or empty lists in case of an error.</remarks>
        public bool AutoHandleErrors { get; set; }

        /// <summary>Gets the Rest Client.</summary>
        /// <value>The Rest client.</value>
        protected IRestClient Client
        {
            get
            {
                return this.client;
            }
        }

        private bool CanSignRequests
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.apiKey) && this.secureApiSecret.Length != 0;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Gets the payload.</summary>
        /// <typeparam name="T">The payload type</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="useAuthorization">If <c>True</c> an authorization header is added.</param>
        /// <returns>An instance of the payload data. Or null if an error ocurrs</returns>
        /// <exception cref="InvalidOperationException">When the API Key or The Secret are <c>null</c> or Empty</exception>
        /// <remarks>None</remarks>
        protected T GetPayload<T>(RestRequest request, bool useAuthorization)
            where T : class
        {
            if (useAuthorization)
            {
                if (!this.CanSignRequests)
                {
                    throw new InvalidOperationException("The request can not be signed");
                }

                var authHeader = this.CreateAuthorizationHeaderContent(request);
                request.AddHeader("Authorization", authHeader);
            }

            var response = this.Client.Execute<ResponseSingle<T>>(request);
            if (response.Data.Success)
            {
                return response.Data.Payload;
            }
            else if (!this.AutoHandleErrors)
            {
                var authHeader = response.Request.Parameters.FirstOrDefault(x => x.Type == ParameterType.HttpHeader && x.Name == "Authorization");
                throw new BitsoException(response.Content, (string)authHeader?.Value);
            }

            return null;
        }

        /// <summary>Gets the payload.</summary>
        /// <typeparam name="T">The payload type</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>An instance of the payload data. Or null if an error ocurrs</returns>
        /// <remarks>None</remarks>
        protected T GetPayload<T>(RestRequest request)
            where T : class
        {
            return this.GetPayload<T>(request, false);
        }

        /// <summary>Gets the payload list.</summary>
        /// <typeparam name="T">The Payload type</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>A list of instances of the requested data</returns>
        /// <remarks>None</remarks>
        protected IList<T> GetPayloadList<T>(RestRequest request)
        {
            return this.GetPayloadList<T>(request, false);
        }

        /// <summary>Gets the payload list.</summary>
        /// <typeparam name="T">The Payload type</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="useAuthorization">If <c>True</c> an authorization header is added.</param>
        /// <returns>A list of instances of the requested data</returns>
        /// <exception cref="InvalidOperationException">When the API Key or The Secret are <c>null</c> or Empty</exception>
        /// <remarks>None</remarks>
        protected IList<T> GetPayloadList<T>(RestRequest request, bool useAuthorization)
        {
            if (useAuthorization)
            {
                if (!this.CanSignRequests)
                {
                    throw new InvalidOperationException("The request can not be signed");
                }

                var authHeader = this.CreateAuthorizationHeaderContent(request);
                request.AddHeader("Authorization", authHeader);
            }

            var response2 = this.Client.Execute<ResponseCollection<T>>(request);

            if (response2.Data.Success)
            {
                return response2.Data.Payload;
            }

            return new List<T>();
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (this.secureApiSecret != null)
                    {
                        this.secureApiSecret.Dispose();
                    }
                }

                this.disposedValue = true;
            }
        }

        private static SecureString CreateSecureApiSecret(string apiSecret)
        {
            var retval = new SecureString();
            for (int i = 0; i < apiSecret.Length; i++)
            {
                retval.AppendChar(apiSecret[i]);
            }

            retval.MakeReadOnly();

            return retval;
        }

        private static string CreateNonce()
        {
            var unixEpoc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var mils = (long)(DateTime.UtcNow - unixEpoc).TotalMilliseconds;

            return string.Format(CultureInfo.InvariantCulture, "{0}", mils);
        }

        private static string GetFullQueryString(List<Parameter> parameters, string resourceName)
        {
            var sb = new StringBuilder();

            var resourceData = parameters.Where(x => x.Type == ParameterType.QueryString).Select(y => string.Format("{0}={1}&", y.Name, y.Value));
            foreach (var item in resourceData)
            {
                sb.Append(item);
            }

            var queryParameters = sb.ToString();
            string retval;
            if (string.IsNullOrEmpty(queryParameters))
            {
                retval = string.Format("{0}/", resourceName);
            }
            else
            {
                var trimmedQs = queryParameters.Substring(0, queryParameters.Length - 1);
                retval = string.Format("{0}?{1}", resourceName, trimmedQs);
            }

            return retval;
        }

        private string CreateAuthorizationHeaderContent(IRestRequest request)
        {
            var nonce = CreateNonce();
            var signature = this.SignRequest(request, nonce);

            return string.Format("Bitso {0}:{1}:{2}", this.apiKey, nonce, signature);
        }

        private string CreateRawSignature(IRestRequest request, string nonce)
        {
            var bodyParameter = request.Parameters.SingleOrDefault(x => x.Type == ParameterType.RequestBody);

            var payload = bodyParameter?.Value;
            var method = Enum.GetName(typeof(Method), request.Method);

            var rawSignature = new StringBuilder();
            rawSignature.Append(nonce);
            rawSignature.Append(method);

            // Appending the Path Part
            var resourceName = GetFullQueryString(request.Parameters, request.Resource);
            rawSignature.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}", this.targetUrl.PathAndQuery, resourceName);

            if (payload != null)
            {
                rawSignature.Append(payload);
            }

            return rawSignature.ToString();
        }

        private string SignRequest(IRestRequest request, string nonce)
        {
            var rawSignature = this.CreateRawSignature(request, nonce);
            var ss = Marshal.PtrToStringAuto(Marshal.SecureStringToBSTR(this.secureApiSecret));
            var shaKeyBytes = Encoding.UTF8.GetBytes(ss);

            using (var shaAlgorithm = new System.Security.Cryptography.HMACSHA256(shaKeyBytes))
            {
                var signatureBytes = Encoding.UTF8.GetBytes(rawSignature);
                var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
                var signatureHashHex = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2", CultureInfo.InvariantCulture))).ToLower(CultureInfo.InvariantCulture);

                return signatureHashHex;
            }
        }
    }
}
