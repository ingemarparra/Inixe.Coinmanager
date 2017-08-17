// -----------------------------------------------------------------------
// <copyright file="BitsoClient.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Text;
    using Inixe.CoinManagement.Bitso.Api.Serialization;
    using RestSharp;

    /// <summary>
    /// Enum SortDirection
    /// </summary>
    /// <remarks>Defines the sorting direction for some operations</remarks>
    public enum SortDirection
    {
        /// <summary>The desending direction</summary>
        Desending,

        /// <summary>The ascending direction</summary>
        Ascending,
    }

    /// <summary>
    /// The Bitso Client
    /// </summary>
    public class BitsoClient : HttpClientBase
    {
        private const string DefaultApiUrl = "https://api.bitso.com/v3";
        private readonly BitsoJsonSerializer serializer;

        /// <summary>Initializes a new instance of the <see cref="BitsoClient"/> class.</summary>
        /// <remarks>This is de default constructor. The URL that will be used is the production URL <c>https://api.bitso.com/v3</c></remarks>
        public BitsoClient()
            : this(string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient"/> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <remarks>None</remarks>
        public BitsoClient(string serverUrl)
            : this(serverUrl, string.Empty, string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient"/> class.</summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        public BitsoClient(string apiKey, SecureString apiSecret)
            : base(DefaultApiUrl, apiKey, apiSecret)
        {
            this.serializer = new BitsoJsonSerializer();
            this.ConfigureClient();
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient"/> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The Api key value</param>
        /// <param name="apiSecret">The Api secret value</param>
        /// <remarks>None</remarks>
        public BitsoClient(string serverUrl, string apiKey, SecureString apiSecret)
            : base(string.IsNullOrWhiteSpace(serverUrl) ? DefaultApiUrl : serverUrl, apiKey, apiSecret)
        {
            this.serializer = new BitsoJsonSerializer();
            this.ConfigureClient();
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient" /> class.</summary>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        public BitsoClient(string serverUrl, string apiKey, string apiSecret)
            : base(string.IsNullOrWhiteSpace(serverUrl) ? DefaultApiUrl : serverUrl, apiKey, apiSecret)
        {
            this.serializer = new BitsoJsonSerializer();
            this.ConfigureClient();
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient"/> class.</summary>
        /// <param name="restClient">The rest client to use. This is often usefull for unit testing, If <c>null</c> a default RestClient will be used</param>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The Api key value</param>
        /// <param name="apiSecret">The Api secret value</param>
        /// <remarks>None</remarks>
        public BitsoClient(IRestClient restClient, string serverUrl, string apiKey, SecureString apiSecret)
            : base(restClient, string.IsNullOrWhiteSpace(serverUrl) ? DefaultApiUrl : serverUrl, apiKey, apiSecret)
        {
            this.serializer = new BitsoJsonSerializer();
            this.ConfigureClient();
        }

        /// <summary>Initializes a new instance of the <see cref="BitsoClient" /> class.</summary>
        /// <param name="restClient">The rest client to use. This is often usefull for unit testing, If <c>null</c> a default RestClient will be used</param>
        /// <param name="serverUrl">The server URL.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="apiSecret">The API secret.</param>
        public BitsoClient(IRestClient restClient, string serverUrl, string apiKey, string apiSecret)
            : base(restClient, string.IsNullOrWhiteSpace(serverUrl) ? DefaultApiUrl : serverUrl, apiKey, apiSecret)
        {
            this.serializer = new BitsoJsonSerializer();
            this.ConfigureClient();
        }

        /// <summary>Gets the serializer.</summary>
        /// <value>The serializer.</value>
        /// <remarks>Gets the serializer instance used by the client, this is useful for changing settings such as tracing and name handling</remarks>
        public BitsoJsonSerializer Serializer
        {
            get
            {
                return this.serializer;
            }
        }

        /// <summary>Gets the available pairs.</summary>
        /// <returns>A list of Currency Pairs</returns>
        public IList<CurrencyPair> GetAvailablePairs()
        {
            var request = new RestRequest("available_books", Method.GET);
            return this.GetPayloadList<CurrencyPair>(request);
        }

        /// <summary>Gets the ticker.</summary>
        /// <param name="pair">The pair.</param>
        /// <returns>The Currency Ticker</returns>
        /// <exception cref="System.ArgumentNullException">When pair is <c>null</c></exception>
        /// <remarks>None</remarks>
        public Ticker GetTicker(CurrencyPair pair)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair));
            }

            return this.GetTicker(pair.BookName);
        }

        /// <summary>Gets the ticker.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns>The Currency Ticker</returns>
        public Ticker GetTicker(string bookName)
        {
            var request = new RestRequest("ticker", Method.GET);
            var book = new Parameter();

            book.Name = "book";
            book.Value = bookName;
            book.Type = ParameterType.QueryString;

            request.AddParameter(book);

            var res = this.GetPayload<Ticker>(request);

            return res;
        }

        /// <summary>Gets all tickers.</summary>
        /// <returns>All Available Tickers</returns>
        public IList<Ticker> GetAllTickers()
        {
            var request = new RestRequest("ticker", Method.GET);

            var res = this.GetPayloadList<Ticker>(request);

            return res;
        }

        /// <summary>Gets the order book.</summary>
        /// <param name="pair">The pair.</param>
        /// <returns>The current Order book</returns>
        public OrderBook GetOrderBook(CurrencyPair pair)
        {
            return this.GetOrderBook(pair, false);
        }

        /// <summary>Gets the order book.</summary>
        /// <param name="pair">The pair.</param>
        /// <param name="aggregatedResults">if set to <c>true</c> aggregated results are returned. Otherwise all orders are returned</param>
        /// <returns>The current Order book</returns>
        /// <exception cref="System.ArgumentNullException">When pair is <c>null</c></exception>
        /// <remarks>None</remarks>
        public OrderBook GetOrderBook(CurrencyPair pair, bool aggregatedResults)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair));
            }

            return this.GetOrderBook(pair.BookName, aggregatedResults);
        }

        /// <summary>Gets the order book.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns>The current Order book</returns>
        public OrderBook GetOrderBook(string bookName)
        {
            return this.GetOrderBook(bookName, false);
        }

        /// <summary>Gets the order book.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="aggregatedResults">if set to <c>true</c> aggregated results are returned. Otherwise all orders are returned</param>
        /// <returns>The current Order book</returns>
        public OrderBook GetOrderBook(string bookName, bool aggregatedResults)
        {
            var request = new RestRequest("order_book", Method.GET);
            var book = new Parameter();
            var aggregate = new Parameter();

            book.Name = "book";
            book.Value = bookName;
            book.Type = ParameterType.QueryString;

            aggregate.Name = "aggregate";
            aggregate.Value = aggregatedResults;
            aggregate.Type = ParameterType.QueryString;

            request.AddParameter(book);
            request.AddParameter(aggregate);

            var res = this.GetPayload<OrderBook>(request);

            return res;
        }

        /// <summary>Gets the trades.</summary>
        /// <param name="pair">The pair.</param>
        /// <returns>A list of Trades</returns>
        /// <exception cref="System.ArgumentNullException">When pair is <c>null</c></exception>
        /// <remarks>None</remarks>
        public IList<Trade> GetTrades(CurrencyPair pair)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair));
            }

            return this.GetTrades(pair.BookName);
        }

        /// <summary>Gets the trades.</summary>
        /// <param name="pair">The pair.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Trades</returns>
        /// <exception cref="System.ArgumentNullException">When pair is <c>null</c></exception>
        /// <remarks>None</remarks>
        public IList<Trade> GetTrades(CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair));
            }

            return this.GetTrades(pair.BookName, markerTag, sortDirection, resultLimit);
        }

        /// <summary>Gets the trades.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns>A list of Trades</returns>
        public IList<Trade> GetTrades(string bookName)
        {
            return this.GetTrades(bookName, string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets the trades.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Trades</returns>
        /// <remarks>None</remarks>
        public IList<Trade> GetTrades(string bookName, string markerTag, SortDirection sortDirection, long resultLimit)
        {
            var request = new RestRequest("trades", Method.GET);
            var book = new Parameter();
            var marker = new Parameter();
            var sort = new Parameter();
            var limit = new Parameter();

            book.Name = "book";
            book.Value = bookName;
            book.Type = ParameterType.QueryString;

            marker.Name = "marker";
            marker.Value = markerTag;
            marker.Type = ParameterType.QueryString;

            sort.Name = "sort";
            sort.Value = sortDirection == SortDirection.Desending ? "desc" : "asc";
            sort.Type = ParameterType.QueryString;

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(book);
            request.AddParameter(marker);
            request.AddParameter(sort);
            request.AddParameter(limit);

            var res = this.GetPayloadList<Trade>(request);

            return res;
        }

        /// <summary>Gets the account information.</summary>
        /// <returns>The Account information</returns>
        /// <remarks>This is an authenticated call.</remarks>
        public AccountInfo GetAccountInfo()
        {
            var request = new RestRequest("account_status", Method.GET);

            var res = this.GetPayload<AccountInfo>(request, true);

            return res;
        }

        /// <summary>Gets the portfolio data.</summary>
        /// <returns>The portfolio data</returns>
        /// <remarks>None</remarks>
        public Portfolio GetPortfolio()
        {
            var request = new RestRequest("balance", Method.GET);

            var res = this.GetPayload<Portfolio>(request, true);

            return res;
        }

        /// <summary>Gets the fee schedule.</summary>
        /// <returns>The fee schedule</returns>
        /// <remarks>None</remarks>
        public AccountFees GetAccountFees()
        {
            var request = new RestRequest("fees", Method.GET);

            var res = this.GetPayload<AccountFees>(request, true);

            return res;
        }

        /// <summary>Gets all ledger entries.</summary>
        /// <returns>A list of ledger entries</returns>
        public IList<ILedgerEntry> GetAllLedgerEntries()
        {
            return this.GetAllLedgerEntries(string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets all ledger entries.</summary>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of ledger entries</returns>
        public IList<ILedgerEntry> GetAllLedgerEntries(string markerTag, SortDirection sortDirection, long resultLimit)
        {
            var request = new RestRequest("ledger", Method.GET);

            var marker = new Parameter();
            var sort = new Parameter();
            var limit = new Parameter();

            marker.Name = "marker";
            marker.Value = markerTag;
            marker.Type = ParameterType.QueryString;

            sort.Name = "sort";
            sort.Value = sortDirection == SortDirection.Desending ? "desc" : "asc";
            sort.Type = ParameterType.QueryString;

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(marker);
            request.AddParameter(sort);
            request.AddParameter(limit);

            var res = this.GetPayloadList<LedgerEntryBase>(request, true).ToList();

            return res.ConvertAll(x => (ILedgerEntry)x);
        }

        /// <summary>Gets a ledger withdrawal.</summary>
        /// <returns>A list of Withdrawal entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerWithdrawalEntry> GetLedgerWithdrawal()
        {
            return this.GetLedgerWithdrawal(string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets a ledger withdrawal.</summary>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Withdrawal entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerWithdrawalEntry> GetLedgerWithdrawal(string markerTag, SortDirection sortDirection, long resultLimit)
        {
            return this.GetFilteredLedger("withdrawals", markerTag, sortDirection, resultLimit).ConvertAll(x => new LedgerWithdrawalEntry(x));
        }

        /// <summary>Gets a ledger trade.</summary>
        /// <returns>A list of trade entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerTradeEntry> GetLedgerTrade()
        {
            return this.GetLedgerTrade(string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets a ledger trade.</summary>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of trade entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerTradeEntry> GetLedgerTrade(string markerTag, SortDirection sortDirection, long resultLimit)
        {
            return this.GetFilteredLedger("trades", markerTag, sortDirection, resultLimit).ConvertAll(x => new LedgerTradeEntry(x));
        }

        /// <summary>Gets a ledger trade fee.</summary>
        /// <returns>A list of trade fee entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerTradeEntry> GetLedgerFee()
        {
            return this.GetLedgerFee(string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets a ledger trade fee.</summary>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of trade fee entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerTradeEntry> GetLedgerFee(string markerTag, SortDirection sortDirection, long resultLimit)
        {
            return this.GetFilteredLedger("fees", markerTag, sortDirection, resultLimit).ConvertAll(x => new LedgerTradeEntry(x));
        }

        /// <summary>Gets a ledger funding.</summary>
        /// <returns>A list of Funding entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerFundingEntry> GetLedgerFunding()
        {
            return this.GetLedgerFunding(string.Empty, SortDirection.Desending, 25);
        }

        /// <summary>Gets a ledger funding.</summary>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Funding entries</returns>
        /// <remarks>None</remarks>
        public IList<LedgerFundingEntry> GetLedgerFunding(string markerTag, SortDirection sortDirection, long resultLimit)
        {
            return this.GetFilteredLedger("fundings", markerTag, sortDirection, resultLimit).ConvertAll(x => new LedgerFundingEntry(x));
        }

        /// <summary>Gets all ledger entries.</summary>
        /// <returns>A list of ledger entries</returns>
        public IList<IWithdrawalBase> GetWithdrawals()
        {
            return this.GetWithdrawals(25);
        }

        /// <summary>Gets all ledger entries.</summary>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of ledger entries</returns>
        public IList<IWithdrawalBase> GetWithdrawals(long resultLimit)
        {
            var request = new RestRequest("withdrawals", Method.GET);

            var limit = new Parameter();

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(limit);

            var res = this.GetPayloadList<WithdrawalBase>(request, true).ToList();

            return res.ConvertAll(x => (IWithdrawalBase)x);
        }

        /// <summary>Gets the banks information.</summary>
        /// <returns></returns>
        public IList<BankCode> GetBanksInfo()
        {
            var request = new RestRequest("mx_bank_codes", Method.GET);
            var res = this.GetPayloadList<BankCode>(request, true);

            return res;
        }

        /// <summary>Gets the ledger applying a filter over the specified resource.</summary>
        /// <param name="filter">The filter the resource to filter.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Entries</returns>
        /// <exception cref="ArgumentException">When the filter is null</exception>
        /// <remarks>None</remarks>
        private List<LedgerEntryBase> GetFilteredLedger(string filter, string markerTag, SortDirection sortDirection, long resultLimit)
        {
            const string baseResourceName = "ledger";

            if (string.IsNullOrWhiteSpace(filter))
            {
                throw new ArgumentException("Invalid filter");
            }

            string resourceName = string.Format("{0}/{1}", baseResourceName, filter);

            var request = new RestRequest(resourceName, Method.GET);

            var marker = new Parameter();
            var sort = new Parameter();
            var limit = new Parameter();

            marker.Name = "marker";
            marker.Value = markerTag;
            marker.Type = ParameterType.QueryString;

            sort.Name = "sort";
            sort.Value = sortDirection == SortDirection.Desending ? "desc" : "asc";
            sort.Type = ParameterType.QueryString;

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(marker);
            request.AddParameter(sort);
            request.AddParameter(limit);

            List<LedgerEntryBase> retval = this.GetPayloadList<LedgerEntryBase>(request, true).ToList();

            return retval;
        }

        /// <summary>Configures the client.</summary>
        /// <remarks>Adds specific items to the rest client</remarks>
        private void ConfigureClient()
        {
            this.Client.UserAgent = "Inixe CoinManager";
            this.Client.AddHandler("application/json", this.serializer);
        }
    }
}
