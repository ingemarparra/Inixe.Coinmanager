// <copyright file="KrakenClientBase.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.Kraken.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using RestSharp;


    public class KrakenClientBase
    {
        private readonly IRestClient restClient;
        private readonly SecureString apiSecret;
        private readonly Uri url;
        private readonly string apiKey;

        protected KrakenClientBase(IRestClient restClient, Uri url, string apiKey, SecureString apiSecret)
        {
            this.restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
            this.url = url ?? throw new ArgumentNullException(nameof(url));
            this.apiKey = !string.IsNullOrWhiteSpace(apiKey) ? apiKey : throw new ArgumentException("Invalid API Key", nameof(apiKey));
            this.apiSecret = apiSecret ?? throw new ArgumentNullException(nameof(apiSecret));
        }

        private long GetNounce()
        {
            return DateTime.Now.Ticks;
        }

        private string GetUrl(string resource)
        {
            throw new NotImplementedException("");
            //return string.Format(this.url., )
        }
    }
}
