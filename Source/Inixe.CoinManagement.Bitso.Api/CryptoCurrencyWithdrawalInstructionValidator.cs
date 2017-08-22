// -----------------------------------------------------------------------
// <copyright file="CryptoCurrencyWithdrawalInstructionValidator.cs" company="Inixe">
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
    using FluentValidation;

    /// <summary>
    /// Class CryptoCurrencyWithdrawalInstructionValidator
    /// </summary>
    /// <remarks>None</remarks>
    internal class CryptoCurrencyWithdrawalInstructionValidator : AbstractValidator<CryptoCurrencyWithdrawalInstruction>
    {
        /// <summary>Initializes a new instance of the <see cref="CryptoCurrencyWithdrawalInstructionValidator"/> class.</summary>
        public CryptoCurrencyWithdrawalInstructionValidator()
        {
            this.RuleFor(ccwi => ccwi.Address)
                .NotEmpty()
                .WithMessage("Invalid Address");

            this.RuleFor(ccwi => ccwi.Amount)
                .GreaterThan(0M)
                .WithMessage("Invalid withdrawal amount");
        }
    }
}
