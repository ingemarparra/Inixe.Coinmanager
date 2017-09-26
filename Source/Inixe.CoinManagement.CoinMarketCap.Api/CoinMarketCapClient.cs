// <copyright file="CoinMarketCapClient.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RateLimiter;
    using RestSharp;

    /// <summary>
    /// Class CoinMarketCapClient
    /// </summary>
    /// <remarks>This is the CoinmarketCap client. It only supports Market data querying.</remarks>
    public class CoinMarketCapClient
    {
        /// <summary>The maximum requests per minute</summary>
        public const int MaxRequestsPerMinute = 6;

        private readonly TimeLimiter gate;
        private readonly Lazy<IList<string>> crytocurrencies;
        private IRestClient httpClient;

        /// <summary>Initializes a new instance of the <see cref="CoinMarketCapClient"/> class.</summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="requestsPerMinute">The requests per minute.</param>
        /// <exception cref="System.ArgumentNullException">httpClient</exception>
        public CoinMarketCapClient(IRestClient httpClient, int requestsPerMinute)
        {
            this.gate = TimeLimiter.GetFromMaxCountByInterval(requestsPerMinute, new TimeSpan(0, 1, 0));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            var serializer = new CoinMarketCapSerializer();

            this.HttpClient.UserAgent = "Inixe CoinManager";
            this.HttpClient.AddHandler("application/json", serializer);

            this.crytocurrencies = new Lazy<IList<string>>(this.LoadCrytoCurrencies);
        }

        /// <summary>Initializes a new instance of the <see cref="CoinMarketCapClient"/> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        public CoinMarketCapClient(Uri serverUrl)
            : this(CreateDefaultRestClient(serverUrl), MaxRequestsPerMinute)
        {
        }

        /// <summary>Gets the cryto currencies list.</summary>
        /// <value>The cryto currencies.</value>
        public IEnumerable<string> CrytoCurrencies
        {
            get
            {
                return this.crytocurrencies.Value;
            }
        }

        /// <summary>Gets the HTTP client.</summary>
        /// <value>The HTTP client.</value>
        protected IRestClient HttpClient
        {
            get
            {
                return this.httpClient;
            }
        }

        /// <summary>Gets the ticker.</summary>
        /// <returns>A list of Tickers with market data for an specific cryto currency</returns>
        public IList<ITicker> GetTicker()
        {
            return this.GetTicker(null, FiatCurrency.None);
        }

        /// <summary>Gets the ticker.</summary>
        /// <param name="convertTo">The convert to.</param>
        /// <returns>A list of Tickers with market data for an specific cryto currency</returns>
        public IList<ITicker> GetTicker(FiatCurrency convertTo)
        {
            return this.GetTicker(null, convertTo);
        }

        /// <summary>Gets the ticker.</summary>
        /// <param name="limit">The limit.</param>
        /// <param name="convertTo">The convert to.</param>
        /// <returns>A list of Tickers with market data for an specific cryto currency</returns>
        public IList<ITicker> GetTicker(int? limit, FiatCurrency convertTo)
        {
            return this.GetTicker(string.Empty, limit, convertTo);
        }

        /// <summary>Gets the ticker.</summary>
        /// <param name="cryptoCurrencyId">The crypto currency identifier.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="convertTo">The convert to.</param>
        /// <returns>A list of Tickers with market data for an specific cryto currency</returns>
        public IList<ITicker> GetTicker(string cryptoCurrencyId, int? limit, FiatCurrency convertTo)
        {
            var res = this.gate.Perform(() => this.GetTickerCore(cryptoCurrencyId, limit, convertTo));

            return res.Result;
        }

        private static IRestClient CreateDefaultRestClient(Uri serverUrl)
        {
            if (serverUrl == null)
            {
                throw new ArgumentNullException(nameof(serverUrl));
            }

            return new RestClient(serverUrl.GetLeftPart(UriPartial.Path));
        }

        private IList<string> LoadCrytoCurrencies()
        {
            try
            {
                var res = this.GetTicker();
                return res.Select(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not load the cryto currencies list", ex);
            }
        }

        private Task<List<ITicker>> GetTickerCore(string cryptoCurrencyId, int? limit, FiatCurrency convertTo)
        {
            const string DefaultResource = "v1/ticker";

            string resource = string.IsNullOrWhiteSpace(cryptoCurrencyId) ? DefaultResource : string.Format("{0}/{1}", DefaultResource, cryptoCurrencyId);

            RestRequest request = new RestRequest(DefaultResource);

            if (limit.HasValue)
            {
                var limitResults = new Parameter();
                limitResults.Type = ParameterType.QueryString;
                limitResults.Value = "limit";
                limitResults.Value = (int)limit;

                request.AddParameter(limitResults);
            }

            if (convertTo != FiatCurrency.None)
            {
                var convertToCurrency = new Parameter();
                convertToCurrency.Type = ParameterType.QueryString;
                convertToCurrency.Value = Enum.GetName(typeof(FiatCurrency), convertTo);
                convertToCurrency.Name = "convert";
            }

            var response = this.HttpClient.Execute<List<Ticker>>(request);
            var retval = response.Data.ConvertAll<ITicker>(x => x);
            return Task.FromResult(retval);
        }
    }
}
