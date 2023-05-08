using Domino.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domino.Infrastructure.Validators
{
    public class DominoValidator : AbstractValidator<DominoDto>
    {
        public DominoValidator()
        {
            RuleFor(domino => domino.FirstValue)
                .NotNull()
                .LessThanOrEqualTo(6);

            RuleFor(domino => domino.SecondValue)
                .NotNull()
                .LessThanOrEqualTo(6);
        }
    }
}
