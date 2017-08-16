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
        /// <summary>Gets or sets the withdrawal operation identifier.</summary>
        /// <value>The withdrawal operation identifier.</value>
        string WithdrawalOperationId { get; set; }

        /// <summary>Gets or sets the withdrawal method.</summary>
        /// <value>The withdrawal method.</value>
        string Method { get; set; }

        /// <summary>Gets or sets the benficiary address.</summary>
        /// <value>The benficiary address.</value>
        string BenficiaryAddress { get; set; }
    }
}
