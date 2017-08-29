// -----------------------------------------------------------------------
// <copyright file="IWithdrawalOperationDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    /// <summary>
    /// Interface IWithdrawalOperationDetails
    /// </summary>
    /// <remarks>Hold the detiails of a Withdrawal operation</remarks>
    public interface IWithdrawalOperationDetails
    {
        /// <summary>Gets the withdrawal operation identifier.</summary>
        /// <value>The withdrawal operation identifier.</value>
        string WithdrawalOperationId { get; }

        /// <summary>Gets the withdrawal method.</summary>
        /// <value>The withdrawal method.</value>
        string Method { get; }

        /// <summary>Gets the benficiary address.</summary>
        /// <value>The benficiary address.</value>
        string BenficiaryAddress { get; }
    }
}
