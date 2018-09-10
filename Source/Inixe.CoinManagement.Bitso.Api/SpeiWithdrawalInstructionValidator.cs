// -----------------------------------------------------------------------
// <copyright file="SpeiWithdrawalInstructionValidator.cs" company="Inixe">
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
    /// Class SpeiWithdrawalInstructionValidator
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{T}" />
    internal class SpeiWithdrawalInstructionValidator : AbstractValidator<SpeiWithdrawalInstruction>
    {
        /// <summary>Initializes a new instance of the <see cref="SpeiWithdrawalInstructionValidator"/> class.</summary>
        public SpeiWithdrawalInstructionValidator()
        {
            this.RuleFor(swi => swi.Clabe)
                .NotEmpty()
                .WithMessage("Invalid Clave");

            this.RuleFor(swi => swi.NumericReference)
               .NotEmpty()
               .WithMessage("Invalid Numeric Reference");

            this.RuleFor(swi => swi.Notes)
               .NotEmpty()
               .WithMessage("Invalid Notes");

            this.RuleFor(swi => swi.BeneficiaryFirstName)
               .NotEmpty()
               .WithMessage("Invalid beneficiary first name");

            this.RuleFor(swi => swi.BeneficiaryLastName)
               .NotEmpty()
               .WithMessage("Invalid beneficiary last name");

            this.RuleFor(swi => swi.Amount)
                .GreaterThan(0M)
                .WithMessage("Invalid withdrawal amount");
        }
    }
}
