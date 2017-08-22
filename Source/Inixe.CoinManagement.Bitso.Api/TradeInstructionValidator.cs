// -----------------------------------------------------------------------
// <copyright file="TradeInstructionValidator.cs" company="Inixe">
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
    /// Class TradeInstructionValidator
    /// </summary>
    /// <remarks>None</remarks>
    internal class TradeInstructionValidator : AbstractValidator<TradeInstruction>
    {
        /// <summary>Initializes a new instance of the <see cref="TradeInstructionValidator"/> class.</summary>
        public TradeInstructionValidator()
        {
            this.RuleFor(ti => ti.MajorCurrencyAmount)
                .NotNull()
                .When(ti => ti.MinorCurrencyAmount == null)
                .WithMessage("invalid order only an amount should be captured, not both");

            this.RuleFor(ti => ti.MinorCurrencyAmount)
                .NotNull()
                .When(ti => ti.MajorCurrencyAmount == null)
                .WithMessage("invalid order only an amount should be captured, not both");

            this.RuleFor(ti => ti.Side)
                .NotEqual(MarketSide.None)
                .WithMessage("invalid order market side");

            this.RuleFor(ti => ti.OrderType)
                .NotEqual(TradeOrderType.None)
                .WithMessage("invalid order type");

            this.RuleFor(ti => ti.Price)
                .NotEqual(0)
                .WithMessage("invalid order price. Price must be more than zero");

            this.RuleFor(ti => ti.BookName)
                .NotEmpty()
                .WithMessage("Invalid Book Name");
        }
    }
}
