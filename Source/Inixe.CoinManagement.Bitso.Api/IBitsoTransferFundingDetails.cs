// -----------------------------------------------------------------------
// <copyright file="IBitsoTransferFundingDetails.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IBitsoTransferFundingDetails
    /// </summary>
    /// <remarks>None</remarks>
    public interface IBitsoTransferFundingDetails
    {
        /// <summary>Gets the name of the sender.</summary>
        /// <value>The name of the sender.</value>
        string SenderName { get; }

        /// <summary>Gets the Transfer Notes.</summary>
        /// <value>The Transfer Notes.</value>
        string Notes { get; }
    }
}
