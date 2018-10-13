// -----------------------------------------------------------------------
// <copyright file="IBitsoClient.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System.Collections.Generic;

    public interface IBitsoClient
    {
        /// <summary>Cancels all orders.</summary>
        /// <returns>A list of the orders thta were cancelled</returns>
        /// <remarks>None</remarks>
        IList<string> CancelAllOrders();

        /// <summary>Cancels the orders specified in <paramref name="ids"/>.</summary>
        /// <param name="ids">The order ids to cancel.</param>
        /// <returns>A list of the orders thta were cancelled</returns>
        /// <remarks>None</remarks>
        IList<string> CancelOrders(IEnumerable<string> ids);

        /// <summary>Cancels the orders supplied in <paramref name="ids"/>.</summary>
        /// <param name="ids">The order ids.</param>
        /// <returns>A list of the orders thta were cancelled</returns>
        /// <remarks>None</remarks>
        IList<string> CancelOrders(string ids);

        bool DocumentUpload(KycDocumentType docType, string filePath);

        AccountFees GetAccountFees();

        AccountInfo GetAccountInfo();

        IList<ILedgerEntry> GetAllLedgerEntries();

        IList<ILedgerEntry> GetAllLedgerEntries(string markerTag, SortDirection sortDirection, long resultLimit);

        IList<Ticker> GetAllTickers();

        IList<CurrencyPair> GetAvailablePairs();

        IList<BankCode> GetBanksInfo();

        IList<BitsoTransferFunding> GetBitsoTransferFundings();

        IList<BitsoTransferFunding> GetBitsoTransferFundings(long? resultLimit);

        IList<BitsoTransferFunding> GetBitsoTransferFundings(string ids);

        IList<BitsoTransferFunding> GetBitsoTransferFundings(string ids, long resultLimit);

        IList<CryptoCurrencyFunding> GetCryptoFundings(long? resultLimit);

        IList<CryptoCurrencyFunding> GetCryptoFundings(string ids);

        IList<CryptoCurrencyFunding> GetCryptoFundings(string ids, long resultLimit);

        IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(long? resultLimit);

        IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(string ids);

        IList<CryptoCurrencyWithdrawal> GetCryptoWithdrawals(string ids, long resultLimit);

        FundingDestination GetFundingDestinations(string currencyCode);

        IList<ITransfer> GetFundings();

        IList<ITransfer> GetFundings(long resultLimit);

        IList<LedgerTradeEntry> GetLedgerFee();

        IList<LedgerTradeEntry> GetLedgerFee(string markerTag, SortDirection sortDirection, long resultLimit);

        IList<LedgerFundingEntry> GetLedgerFunding();

        IList<LedgerFundingEntry> GetLedgerFunding(string markerTag, SortDirection sortDirection, long resultLimit);

        IList<LedgerTradeEntry> GetLedgerTrade();

        IList<LedgerTradeEntry> GetLedgerTrade(string markerTag, SortDirection sortDirection, long resultLimit);

        IList<LedgerWithdrawalEntry> GetLedgerWithdrawal();

        IList<LedgerWithdrawalEntry> GetLedgerWithdrawal(string markerTag, SortDirection sortDirection, long resultLimit);

        IList<TradeOrder> GetOpenTradeOrders(CurrencyPair pair);

        IList<TradeOrder> GetOpenTradeOrders(CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<TradeOrder> GetOpenTradeOrders(string bookName);

        IList<TradeOrder> GetOpenTradeOrders(string bookName, string markerTag, SortDirection sortDirection, long resultLimit);

        OrderBook GetOrderBook(CurrencyPair pair);

        OrderBook GetOrderBook(CurrencyPair pair, bool aggregatedResults);

        OrderBook GetOrderBook(string bookName);

        OrderBook GetOrderBook(string bookName, bool aggregatedResults);

        Portfolio GetPortfolio();

        IList<SpeiFunding> GetSpeiFundings();

        IList<SpeiFunding> GetSpeiFundings(long? resultLimit);

        IList<SpeiFunding> GetSpeiFundings(string ids);

        IList<SpeiFunding> GetSpeiFundings(string ids, long resultLimit);

        IList<SpeiWithdrawal> GetSpeiWithdrawals(long? resultLimit);

        IList<SpeiWithdrawal> GetSpeiWithdrawals(string ids);

        IList<SpeiWithdrawal> GetSpeiWithdrawals(string ids, long resultLimit);

        Ticker GetTicker(CurrencyPair pair);

        Ticker GetTicker(string bookName);

        IList<TradeOrder> GetTradeOrderByOrderId(string id);

        IList<TradeInfo> GetTrades(CurrencyPair pair);

        IList<TradeInfo> GetTrades(CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<TradeInfo> GetTrades(string bookName);

        IList<TradeInfo> GetTrades(string bookName, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<Trade> GetUserTradeByOrderId(string id);

        IList<Trade> GetUserTrades(CurrencyPair pair);

        IList<Trade> GetUserTrades(CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<Trade> GetUserTrades(string bookName);

        IList<Trade> GetUserTrades(string ids, CurrencyPair pair, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<Trade> GetUserTrades(string bookName, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<Trade> GetUserTrades(string ids, string bookName, string markerTag, SortDirection sortDirection, long resultLimit);

        IList<ITransfer> GetWithdrawals();

        IList<ITransfer> GetWithdrawals(long resultLimit);

        TradeOrder PlaceOrder(TradeInstruction instruction);

        CryptoCurrencyWithdrawal WithdrawCrypto(CryptoCurrencyWithdrawalInstruction instruction, TransferMethod method);

        SpeiWithdrawal WithdrawSpei(SpeiWithdrawalInstruction instruction);
    }
}