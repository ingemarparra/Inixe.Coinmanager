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
        /// <summary>The default filter limit for all calls that requiere a limit parameter If ommited</summary>
        public const int DefaultFilterLimit = 25;

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
        public IList<TradeInfo> GetTrades(CurrencyPair pair)
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
        public IList<TradeInfo> GetTrades(CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit)
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
        public IList<TradeInfo> GetTrades(string bookName)
        {
            return this.GetTrades(bookName, string.Empty, SortDirection.Desending, DefaultFilterLimit);
        }

        /// <summary>Gets the trades.</summary>
        /// <param name="bookName">Name of the book.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list of Trades</returns>
        /// <remarks>None</remarks>
        public IList<TradeInfo> GetTrades(string bookName, string markerTag, SortDirection sortDirection, long resultLimit)
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

            var res = this.GetPayloadList<TradeInfo>(request);

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
            return this.GetAllLedgerEntries(string.Empty, SortDirection.Desending, DefaultFilterLimit);
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
            return this.GetLedgerWithdrawal(string.Empty, SortDirection.Desending, DefaultFilterLimit);
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
            return this.GetLedgerTrade(string.Empty, SortDirection.Desending, DefaultFilterLimit);
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
            return this.GetLedgerFee(string.Empty, SortDirection.Desending, DefaultFilterLimit);
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
            return this.GetLedgerFunding(string.Empty, SortDirection.Desending, DefaultFilterLimit);
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

        /// <summary>Gets the last 25 withdrawals.</summary>
        /// <returns>A list with the Account Withdrawals</returns>
        /// <remarks>None</remarks>
        public IList<ITransfer> GetWithdrawals()
        {
            return this.GetWithdrawals(DefaultFilterLimit);
        }

        /// <summary>Gets all the withdrawal transfers.</summary>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list with the Account Withdrawals</returns>
        /// <remarks>None</remarks>
        public IList<ITransfer> GetWithdrawals(long resultLimit)
        {
            var request = new RestRequest("withdrawals", Method.GET);

            var limit = new Parameter();

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(limit);

            var res = this.GetPayloadList<WithdrawalBase>(request, true).ToList();

            return res.ConvertAll(x => (ITransfer)x);
        }

        /// <summary>Gets the crypto currency withdrawals by id.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all Crypto Currency Withdrawals are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                throw new ArgumentException("Invalid Id", nameof(ids));
            }

            return this.GetCryptoWithdrawals(ids, DefaultFilterLimit);
        }

        /// <summary>Gets the All crypto currency withdrawals.</summary>
        /// <param name="resultLimit">The result limit. If <c>null</c> the default value is used and only 25 items are returned</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(long? resultLimit)
        {
            return this.GetCryptoWithdrawals(string.Empty, resultLimit ?? DefaultFilterLimit);
        }

        /// <summary>Gets the crypto currency withdrawals.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all Crypto Currency Withdrawals are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(string ids, long resultLimit)
        {
            return this.GetFilteredTransfers<WithdrawalBase>("withdrawals", ids, TransferMethod.Sp, true, resultLimit).ConvertAll(x => new CryptoCurrencyWithdrawal(x));
        }

        /// <summary>Gets the spei withdrawals by id.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all SPEI Withdrawals are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiWithdrawal> GetSpeiWithdrawals(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                throw new ArgumentException("Invalid Id", nameof(ids));
            }

            return this.GetSpeiWithdrawals(ids, DefaultFilterLimit);
        }

        /// <summary>Gets all the SPEI withdrawals.</summary>
        /// <param name="resultLimit">The result limit. If <c>null</c> the default value is used and only 25 items are returned</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiWithdrawal> GetSpeiWithdrawals(long? resultLimit)
        {
            return this.GetSpeiWithdrawals(string.Empty, resultLimit ?? DefaultFilterLimit);
        }

        /// <summary>Gets the SPEI withdrawals.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all SPEI Withdrawals are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiWithdrawal> GetSpeiWithdrawals(string ids, long resultLimit)
        {
            return this.GetFilteredTransfers<WithdrawalBase>("withdrawals", ids, TransferMethod.Sp, false, resultLimit).ConvertAll(x => new SpeiWithdrawal(x));
        }

        /// <summary>Gets the last 25 fundings.</summary>
        /// <returns>A list of account Funding transfers</returns>
        /// <remarks>None</remarks>
        public IList<ITransfer> GetFundings()
        {
            return this.GetFundings(DefaultFilterLimit);
        }

        /// <summary>Gets all the fundings.</summary>
        /// <param name="resultLimit">The result limit. Max if 100</param>
        /// <returns>A list of account Funding transfers</returns>
        /// <remarks>None</remarks>
        public IList<ITransfer> GetFundings(long resultLimit)
        {
            var request = new RestRequest("fundings", Method.GET);

            var limit = new Parameter();

            limit.Name = "limit";
            limit.Value = resultLimit;
            limit.Type = ParameterType.QueryString;

            request.AddParameter(limit);

            var res = this.GetPayloadList<FundingBase>(request, true).ToList();

            return res.ConvertAll(x => (ITransfer)x);
        }

        /// <summary>Gets the crypto currency fundings by id.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all Crypto Currency fundings are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyFunding> GetCryptoFundings(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                throw new ArgumentException("Invalid Id", nameof(ids));
            }

            return this.GetCryptoFundings(ids, DefaultFilterLimit);
        }

        /// <summary>Gets the All crypto currency fundings.</summary>
        /// <param name="resultLimit">The result limit. If <c>null</c> the default value is used and only 25 items are returned</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyFunding> GetCryptoFundings(long? resultLimit)
        {
            return this.GetCryptoFundings(string.Empty, resultLimit ?? DefaultFilterLimit);
        }

        /// <summary>Gets the crypto currency fundings.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all Crypto Currency fundings are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<CryptoCurrencyFunding> GetCryptoFundings(string ids, long resultLimit)
        {
            return this.GetFilteredTransfers<FundingBase>("fundings", ids, TransferMethod.Sp, true, resultLimit).ConvertAll(x => new CryptoCurrencyFunding(x));
        }

        /// <summary>Gets the spei fundings by id.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all SPEI fundings are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiFunding> GetSpeiFundings(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                throw new ArgumentException("Invalid Id", nameof(ids));
            }

            return this.GetSpeiFundings(ids, DefaultFilterLimit);
        }

        /// <summary>Gets all the SPEI fundings.</summary>
        /// <param name="resultLimit">The result limit. If <c>null</c> the default value is used and only 25 items are returned</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiFunding> GetSpeiFundings(long? resultLimit)
        {
            return this.GetSpeiFundings(string.Empty, resultLimit ?? DefaultFilterLimit);
        }

        /// <summary>Gets the SPEI fundings.</summary>
        /// <param name="ids">The a list with ids to search for.If <c>null</c> or Empty all SPEI fundings are returned.
        /// The list can be a string separated by spaces, commans, colons and semicolons</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>A list with the Entries found</returns>
        /// <remarks>None</remarks>
        public IList<SpeiFunding> GetSpeiFundings(string ids, long resultLimit)
        {
            return this.GetFilteredTransfers<FundingBase>("fundings", ids, TransferMethod.Sp, false, resultLimit).ConvertAll(x => new SpeiFunding(x));
        }

        /// <summary>Gets the banks information.</summary>
        /// <returns>A list with the registered banks data.</returns>
        /// <remarks>None</remarks>
        public IList<BankCode> GetBanksInfo()
        {
            var request = new RestRequest("mx_bank_codes", Method.GET);
            var res = this.GetPayloadList<BankCode>(request, true);

            return res;
        }

        /// <summary>Gets the user trade by order identifier.</summary>
        /// <param name="id">The order identifier.</param>
        /// <returns>if valid and found, the requested Trade is returned. Otherwise null is returned.</returns>
        /// <exception cref="ArgumentException">When <paramref name="id"/> represents a list of ids or is <c>null</c></exception>
        /// <remarks>None</remarks>
        public Trade GetUserTradeByOrderId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid Order Id", nameof(id));
            }

            // To avoid Id lists
            var idList = id.Replace('-', ',');
            var parametrizedIds = GetParametrizedResourceName("order_trades", idList);
            var verificationIds = string.Format("order_trades/{0}", idList);

            if (verificationIds != parametrizedIds)
            {
                // It's a list!!
                throw new ArgumentException("Only single operations are allowed", nameof(id));
            }

            var res = this.GetFilteredOrders("order_trades", id, null);
            return res.Count > 0 ? res[0] : null;
        }

        /// <summary>Gets the user trades.</summary>
        /// <param name="bookName">Name of the currency book.</param>
        /// <returns>if the requested book Trades are returned. Otherwise null is returned.</returns>
        /// <exception cref="ArgumentException">Invalid limit. Maximum limit is 100 - resultLimit</exception>
        public IList<Trade> GetUserTrades(string bookName)
        {
            return this.GetUserTrades(string.Empty, bookName, string.Empty, SortDirection.Desending, DefaultFilterLimit);
        }

        /// <summary>Gets the user trades.</summary>
        /// <param name="bookName">Name of the currency book.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>if the requested book Trades are returned. Otherwise null is returned.</returns>
        /// <exception cref="ArgumentException">Invalid limit. Maximum limit is 100 - resultLimit</exception>
        public IList<Trade> GetUserTrades(string bookName, string markerTag, SortDirection sortDirection, long resultLimit)
        {
            return this.GetUserTrades(string.Empty, bookName, markerTag, sortDirection, resultLimit);
        }

        /// <summary>Gets the user trades.</summary>
        /// <param name="ids">The trade ids to look for.</param>
        /// <param name="bookName">Name of the currency book.</param>
        /// <param name="markerTag">The marker tag.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="resultLimit">The result limit.</param>
        /// <returns>if valid and found, the requested Trades are returned. Otherwise null is returned.</returns>
        /// <exception cref="ArgumentException">Invalid limit. Maximum limit is 100 - resultLimit</exception>
        public IList<Trade> GetUserTrades(string ids, string bookName, string markerTag, SortDirection sortDirection, long resultLimit)
        {
            if (resultLimit > 100)
            {
                throw new ArgumentException("Invalid limit. Maximum limit is 100", nameof(resultLimit));
            }

            var marker = new Parameter();
            var sort = new Parameter();
            var limit = new Parameter();
            var book = new Parameter();

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

            var parameters = new List<Parameter>();
            parameters.Add(book);
            parameters.Add(marker);
            parameters.Add(sort);

            if (string.IsNullOrEmpty(ids))
            {
                parameters.Add(limit);
            }

            return this.GetFilteredOrders("user_trades", ids, parameters);
        }

        private static string GetParametrizedResourceName(string resource, string ids)
        {
            StringBuilder resourceName = new StringBuilder();

            resourceName.Append(resource);
            if (!string.IsNullOrEmpty(ids))
            {
                var rx = new System.Text.RegularExpressions.Regex(@"[-,;:\s]+");
                resourceName.AppendFormat("/{0}", rx.Replace(ids, "-"));
            }

            return resourceName.ToString();
        }

        private IList<Trade> GetFilteredOrders(string resource, string ids, IEnumerable<Parameter> parameters)
        {
            var resourceName = GetParametrizedResourceName(resource, ids);

            var request = new RestRequest(resourceName, Method.GET);

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    request.AddParameter(p);
                }
            }

            return this.GetPayloadList<Trade>(request, true);
        }

        private List<T> GetFilteredTransfers<T>(string resource, string ids, TransferMethod methodFilter, bool filterExcept, long resultLimit)
            where T : ITransfer
        {
            if (resultLimit > 100)
            {
                throw new ArgumentException("Invalid limit. Maximum limit is 100", nameof(resultLimit));
            }

            var resourceName = GetParametrizedResourceName(resource, ids);
            var request = new RestRequest(resourceName, Method.GET);

            var limit = new Parameter();

            limit.Name = "limit";
            limit.Type = ParameterType.QueryString;
            limit.Value = resultLimit;

            if (string.IsNullOrEmpty(ids))
            {
                request.AddParameter(limit);
            }

            Func<T, bool> filterBySelector = x => x.Method == methodFilter;
            Func<T, bool> filterExceptSelector = x => x.Method != methodFilter;
            var filter = !filterExcept ? filterBySelector : filterExceptSelector;

            var transfers = this.GetPayloadList<T>(request, true);
            return transfers.Where(filter).ToList();
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

            if (resultLimit > 100)
            {
                throw new ArgumentException("Invalid limit. Maximum limit is 100", nameof(resultLimit));
            }

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
