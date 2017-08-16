// -----------------------------------------------------------------------
// <copyright file="ITradeOperationDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    /// <summary>
    /// Interface ITradeOperationDetails
    /// </summary>
    /// <remarks>Holds the detiails for a trade operation</remarks>
    public interface ITradeOperationDetails
    {
        /// <summary>Gets or sets the trade identifier.</summary>
        /// <value>The trade identifier.</value>
        long TradeId { get; set; }

        /// <summary>Gets or sets the order identifier.</summary>
        /// <value>The order identifier.</value>
        string OrderId { get; set; }
    }
}
