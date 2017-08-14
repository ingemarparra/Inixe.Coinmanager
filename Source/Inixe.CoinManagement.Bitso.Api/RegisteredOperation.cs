// -----------------------------------------------------------------------
// <copyright file="RegisteredOperation.cs" company="Inixe">
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

    public enum TransactionType
    {
        Fee,
        Withdrawal,
        Funding,
        Trade,
    }

    /// <summary>
    /// Class RegisteredOperation
    /// </summary>
    /// <remarks>None</remarks>
    public class Operation
    {
        public string Id { get; set; }

        public TransactionType Kind { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
