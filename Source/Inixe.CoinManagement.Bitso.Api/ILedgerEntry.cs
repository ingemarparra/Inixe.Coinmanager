// -----------------------------------------------------------------------
// <copyright file="ILedgerEntry.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    /// <summary>
    /// Interface ILedgerEntry
    /// </summary>
    /// <seealso cref="Inixe.CoinManagement.Bitso.Api.ILedgerEntryBase" />
    /// <remarks>Expands the <see cref="ILedgerEntryBase"/> interface adding the Details data retrival.</remarks>
    public interface ILedgerEntry : ILedgerEntryBase
    {
        /// <summary>Gets the details.</summary>
        /// <typeparam name="T">The details Type</typeparam>
        /// <returns>A details instance</returns>
        T GetDetails<T>()
            where T : IFundingOperationDetails, IWithdrawalOperationDetails, ITradeOperationDetails;
    }
}
